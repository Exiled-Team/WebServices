using ExiledWebServices.Components.Core;
using ExiledWebServices.Deployment;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Components.Configs;

/// <summary>
/// Represents the documentation configuration.
/// </summary>
public class Documentation : IConfig
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

    /// <summary>
    /// Gets or sets all articles that should be displayed.
    /// </summary>
    public List<DocumentationCard> Articles { get; set; } = new();
}
