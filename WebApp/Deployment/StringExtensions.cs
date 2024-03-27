using System.Text;
using System.Text.RegularExpressions;

namespace WebApp.Deployment;

  /// <summary>
  /// Various string extension methods
  /// </summary>
  internal static class StringExtensions
  {
    private static string ToCamelOrPascalCase(string str, Func<char, char> firstLetterTransform)
    {
      string str1 = Regex.Replace(str, "([_\\-])(?<char>[a-z])", (MatchEvaluator) (match => match.Groups["char"].Value.ToUpperInvariant()), RegexOptions.IgnoreCase);
      return string.Concat(firstLetterTransform(str1[0]).ToString(), str1.AsSpan(1));
    }

    /// <summary>
    /// Converts the string with underscores (this_is_a_test) or hyphens (this-is-a-test) to
    /// camel case (thisIsATest). Camel case is the same as Pascal case, except the first letter
    /// is lowercase.
    /// </summary>
    /// <param name="str">String to convert</param>
    /// <returns>Converted string</returns>
    public static string ToCamelCase(this string str) => StringExtensions.ToCamelOrPascalCase(str, new Func<char, char>(char.ToLowerInvariant));

    /// <summary>
    /// Converts the string with underscores (this_is_a_test) or hyphens (this-is-a-test) to
    /// pascal case (ThisIsATest). Pascal case is the same as camel case, except the first letter
    /// is uppercase.
    /// </summary>
    /// <param name="str">String to convert</param>
    /// <returns>Converted string</returns>
    public static string ToPascalCase(this string str) => StringExtensions.ToCamelOrPascalCase(str, new Func<char, char>(char.ToUpperInvariant));

    /// <summary>
    /// Converts the string from camelcase (thisIsATest) to a hyphenated (this-is-a-test) or
    /// underscored (this_is_a_test) string
    /// </summary>
    /// <param name="str">String to convert</param>
    /// <param name="separator">Separator to use between segments</param>
    /// <returns>Converted string</returns>
    public static string FromCamelCase(this string str, string separator)
    {
      str = char.ToLower(str[0]).ToString() + str.Substring(1);
      str = Regex.Replace(str.ToCamelCase(), "(?<char>[A-Z])", (MatchEvaluator) (match => separator + match.Groups["char"].Value.ToLowerInvariant()));
      return str;
    }

    /// <summary>
    /// Converts the specified string to snake_case format.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The string converted to snake_case format.</returns>
    public static string ToSnakeCase(this string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;

      StringBuilder snakeCase = new StringBuilder();
      bool previousCharWasUpper = false;
      bool previousCharWasLetter = false;

      foreach (char currentChar in input)
      {
        if (char.IsUpper(currentChar))
        {
          if (!previousCharWasUpper && previousCharWasLetter)
          {
            snakeCase.Append('_');
          }
          snakeCase.Append(char.ToLower(currentChar));
          previousCharWasUpper = true;
        }
        else if (char.IsLetter(currentChar))
        {
          snakeCase.Append(currentChar);
          previousCharWasUpper = false;
          previousCharWasLetter = true;
        }
        else
        {
          previousCharWasUpper = false;
          previousCharWasLetter = false;
          snakeCase.Append(currentChar);
        }
      }

      return snakeCase.ToString();
    }
  }