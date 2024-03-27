using ExiledWebServices.Components.Cards;
using ExiledWebServices.Deployment;

namespace ExiledWebServices.Configs;

/// <summary>
/// Represents the documentation configuration.
/// </summary>
public class Documentation : IArticlesConfig<ArticleCard>
{
    public Documentation()
    {
    }

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public string Identifier { get; } = "Documentation";

    /// <inheritdoc />
    public string Directory { get; } = "Documentation";

    /// <inheritdoc />
    public string TargetPage { get; set; } = "Documentation";

    /// <inheritdoc />
    public bool IsCategory { get; set; } = true;

    /// <inheritdoc />
    public string TitleSpan { get; set; } = "Exiled";

    /// <inheritdoc />
    public string Title { get; set; } = "Documentation";

    /// <inheritdoc />
    public string Subtitle { get; set; } = "Discover the wonders of the Exiled Framework with our comprehensive guides!";

    /// <inheritdoc />
    public List<ArticleCard> Articles { get; set; } = new();
}
