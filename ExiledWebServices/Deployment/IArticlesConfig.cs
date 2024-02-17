using YamlDotNet.Serialization;

namespace ExiledWebServices.Deployment;

/// <summary>
/// Represents a configuration interface.
/// </summary>
public interface IArticlesConfig<T> : IConfig
{
    /// <summary>
    /// Gets the name of the configuration.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// Gets the directory of the configuration.
    /// </summary>
    string Directory { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the configuration is enabled.
    /// </summary>
    bool IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the target page of the configuration.
    /// </summary>
    string TargetPage { get; set; }

    /// <summary>
    /// Gets or sets the title span.
    /// </summary>
    string TitleSpan { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Gets or sets the subtitle.
    /// </summary>
    string Subtitle { get; set; }

    /// <summary>
    /// Gets or sets the articles.
    /// </summary>
    List<T> Articles { get; set; }
}
