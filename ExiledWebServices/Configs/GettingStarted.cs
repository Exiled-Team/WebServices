using ExiledWebServices.Components.Core;
using ExiledWebServices.Deployment;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

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
    public string TargetPage { get; set; } = "GettingStarted";

    /// <summary>
    /// Gets or sets the title span.
    /// </summary>
    public string TitleSpan { get; set; } = "Getting";

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    public string Title { get; set; } = "Started";

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    public string Subtitle { get; set; } = "Begin your Exiled journey: Immerse yourself in the world of Modding and Plugin Development to uncover limitless opportunities for creativity and innovation!";

    /// <summary>
    /// Gets or sets all articles that should be displayed.
    /// </summary>
    public List<DocumentationCard> Articles { get; set; } = new();
}
