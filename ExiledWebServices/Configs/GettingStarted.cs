using ExiledWebServices.Components.Core;
using ExiledWebServices.Deployment;

namespace ExiledWebServices.Components.Configs;

/// <summary>
/// Represents the documentation configuration.
/// </summary>
public class GettingStarted : IArticlesConfig<DocumentationCard>
{
    public GettingStarted()
    {
    }

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public string Identifier { get; } = "GettingStarted";

    /// <inheritdoc />
    public string Directory { get; } = "Documentation/";

    /// <inheritdoc />
    public bool IsCategory { get; set; } = false;

    /// <inheritdoc />
    public string TargetPage { get; set; } = "GettingStarted";

    /// <inheritdoc />
    public string TitleSpan { get; set; } = "Getting";

    /// <inheritdoc />
    public string Title { get; set; } = "Started";

    /// <inheritdoc />
    public string Subtitle { get; set; } = "Begin your Exiled journey: Immerse yourself in the world of Modding and Plugin Development to uncover limitless opportunities for creativity and innovation!";

    /// <inheritdoc />
    public List<DocumentationCard> Articles { get; set; } = new();
}
