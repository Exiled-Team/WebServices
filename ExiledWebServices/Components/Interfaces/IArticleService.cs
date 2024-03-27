using ExiledWebServices.Components.Markdown;

namespace ExiledWebServices.Components.Interfaces;

/// <summary>
/// Service for managing articles loaded from Markdown files.
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Gets the Markdown article with the specified name.
    /// </summary>
    /// <param name="name">The name of the article.</param>
    /// <returns>The Markdown article with the specified name, or null if not found.</returns>
    public MarkdownArticle? GetArticleByName(string name);
}