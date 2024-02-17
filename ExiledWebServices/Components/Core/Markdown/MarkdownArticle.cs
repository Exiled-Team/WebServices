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
/// Represents a Markdown article with metadata.
/// </summary>
public partial class MarkdownArticle
{
    private static readonly char[] separators = new[] { '\n', '\r' };

    /// <summary>
    /// Gets or sets the name of the Markdown article.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the title of the Markdown article.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the preview of the Markdown article.
    /// </summary>
    public string Preview { get; set; }

    /// <summary>
    /// Gets or sets the icon associated with the Markdown article.
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// Gets or sets the next article.
    /// </summary>
    public string NextArticle { get; set; }

    /// <summary>
    /// Gets or sets the previous article.
    /// </summary>
    public string PreviousArticle { get; set; }

    /// <summary>
    /// Gets or sets the authors of the article.
    /// </summary>
    public Dictionary<string, string> Authors { get; set; }

    /// <summary>
    /// Gets or sets the date of the article.
    /// </summary>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the Markdown content of the article.
    /// </summary>
    public string MarkdownText { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the article can be displayed into articles page.
    /// </summary>
    public bool CanBeDisplayed { get; set; }

    /// <summary>
    /// Reads a Markdown file and creates a MarkdownArticle object from it.
    /// </summary>
    /// <param name="filePath">The path to the Markdown file.</param>
    /// <returns>A MarkdownArticle object representing the Markdown file.</returns>
    public static MarkdownArticle FromMarkdownFile(string filePath)
    {
        string markdownContent = File.ReadAllText(filePath);

        MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        MarkdownDocument document = Markdown.Parse(markdownContent, pipeline);

        string title = null;
        string preview = null;
        string iconClass = null;
        Dictionary<string, string> authors = new();
        string date = null;
        string nextArticle = null;
        string previousArticle = null;
        bool canBeDisplayed = false;

        string[] htmlLines = markdownContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < htmlLines.Length; i++)
        {
            string line = htmlLines[i];
            if (line.StartsWith("[icon:"))
            {
                Match match = IconRegex().Match(line);

                if (match.Success)
                {
                    string value = match.Groups[1].Value;

                    if (string.IsNullOrEmpty(iconClass))
                    {
                        iconClass = value;
                        htmlLines[i] = string.Empty;
                    }
                    else
                        htmlLines[i] = $"<a class=\"hover-2 icon-label\"><ion-icon name=\"{value}\"></ion-icon></a>";
                }
            }
            else if (line.StartsWith("[displayable"))
            {
                canBeDisplayed = true;
                htmlLines[i] = string.Empty;
            }
            else if (line.StartsWith("[preview: "))
            {
                Match match = PreviewRegex().Match(line);

                if (match.Success && string.IsNullOrEmpty(preview))
                {
                    preview = match.Groups[1].Value;
                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[title:"))
            {
                Match match = TitleRegex().Match(line);

                if (match.Success && string.IsNullOrEmpty(title))
                {
                    title = match.Groups[1].Value;
                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[next:"))
            {
                string pattern = @"\[next:\s*(?<title>[^\]]+)\]";

                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    nextArticle = match.Groups["title"].Value;
                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[previous:"))
            {
                string pattern = @"\[previous:\s*(?<title>[^\]]+)\]";

                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    previousArticle = match.Groups["title"].Value;
                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[date:"))
            {
                Match match = DateRegex().Match(line);
                if (match.Success)
                {
                    date = match.Groups["date"].Value;
                    htmlLines[i] = string.Empty;
                }
            }
            else if (line.StartsWith("[authors: "))
            {
                Match match = ContributorsRegex().Match(line);

                if (match.Success)
                {
                    string namesString = match.Groups["names"].Value;
                    string[] names = namesString.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    foreach (string name in names)
                    {
                        string[] parts = name.Split('|');
                        string arName = parts[0].Trim();
                        string arLink = parts.Length > 1 ? parts[1].Trim() : "";
                        authors.Add(arName, arLink);
                    }

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

        MarkdownArticle article = new MarkdownArticle
        {
            Name = Path.GetFileNameWithoutExtension(filePath),
            Title = title,
            Icon = iconClass,
            NextArticle = nextArticle,
            PreviousArticle = previousArticle,
            Authors = authors,
            Date = date,
            MarkdownText = htmlContent,
            Preview = preview,
            CanBeDisplayed = canBeDisplayed,
        };

        return article;
    }

    [GeneratedRegex(@"\[img\s+src=""([^""]*)""(?:\s*width:\s*(\d+)\s*px)?(?:\s*height:\s*(\d+)\s*px)?\]")]
    private static partial Regex ImgRegex();

    [GeneratedRegex(@"\[icon:\s*(.*?)\]")]
    private static partial Regex IconRegex();

    [GeneratedRegex(@"\[title:\s*(.*?)\]")]
    private static partial Regex TitleRegex();

    [GeneratedRegex(@"\[preview:\s*(.*?)\]")]
    private static partial Regex PreviewRegex();

    [GeneratedRegex(@"\[date:\s*(?<date>[^\]]+)\]")]
    private static partial Regex DateRegex();

    [GeneratedRegex(@"\[authors:\s*(?<names>.*?)\]")]
    private static partial Regex ContributorsRegex();
}