using System.Text;
using System.Text.RegularExpressions;
using Markdig;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Components.Web.HtmlRendering;

namespace ExiledWebServices.Components.Core;

/// <summary>
/// Represents a Markdown translation with metadata.
/// </summary>
public partial class MarkdownTranslation
{
    private static readonly char[] separators = new[] { '\n', '\r' };

    /// <summary>
    /// Gets or sets the name of the Markdown translation.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the language of the Markdown translation.
    /// </summary>
    public string Language { get; set; }

    /// <summary>
    /// Gets or sets the Markdown content of the translation.
    /// </summary>
    public string MarkdownText { get; set; }

    /// <summary>
    /// Reads a Markdown file and creates a MarkdownTranslation object from it.
    /// </summary>
    /// <param name="filePath">The path to the Markdown file.</param>
    /// <returns>A MarkdownArticle object representing the Markdown file.</returns>
    public static MarkdownTranslation FromMarkdownFile(string filePath)
    {
        string markdownContent = File.ReadAllText(filePath);

        MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        MarkdownDocument document = Markdown.Parse(markdownContent, pipeline);

        string language = null;

        string[] htmlLines = markdownContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < htmlLines.Length; i++)
        {
            string line = htmlLines[i];
            if (line.StartsWith("[language:"))
            {
                Match match = LangRegex().Match(line);

                if (match.Success)
                {
                    string value = match.Groups[1].Value;

                    if (string.IsNullOrEmpty(language))
                        language = value;

                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[separator:"))
            {
                string num = string.Empty;

                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                        num += c;
                }

                int startIndex = line.IndexOf("[separator:") + "[separator:".Length;
                int endIndex = line.IndexOf("]", startIndex);
                htmlLines[i] = $"<div style=\"height: {num}px\"></style>";
            }
            else if (line.StartsWith("[newline]") || line.StartsWith("[n]") || line.StartsWith("[br]"))
            {
                htmlLines[i] = "<div style=\"margin-block-end: 20px\"></div>\n";
            }
        }

        StringBuilder markdownBuilder = new();

        foreach (string line in htmlLines)
            markdownBuilder.AppendLine(line);

        markdownContent = markdownBuilder.ToString();

        string htmlContent = Markdown.ToHtml(markdownContent, pipeline);
        htmlContent = htmlContent
            .Replace("<span", "<span class=\"md-span\"")
            .Replace("<img", "<img class=\"md-img\"")
            .Replace("<ul", "<ul class=\"md-ul\"")
            .Replace("<li>", "<li class=\"md-li\">");

        MarkdownTranslation article = new MarkdownTranslation
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            Language = language,
            MarkdownText = htmlContent
        };

        return article;
    }

    [GeneratedRegex(@"\[language:\s*(.*?)\]")]
    private static partial Regex LangRegex();
}