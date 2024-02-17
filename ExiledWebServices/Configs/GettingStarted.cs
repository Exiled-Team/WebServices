using ExiledWebServices.Components.Core;
using ExiledWebServices.Deployment;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Components.Configs;

/// <summary>
/// Represents the documentation configuration.
/// </summary>
public class GettingStarted : IConfig
{
    public GettingStarted()
    {
    }

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public string Identifier { get; } = "GettingStarted";

    /// <inheritdoc />
    public string Directory { get; } = "Documentation/GettingStarted";

    /// <inheritdoc />
    public string TargetPage { get; set; } = "GettingStarted";

    /// <summary>
    /// Gets or sets all articles that should be displayed.
    /// </summary>
    public List<DocumentationCard> Articles { get; set; } = new();
}
