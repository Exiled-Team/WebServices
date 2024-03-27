using WebApp.Deployment;

namespace WebApp.Configs;

/// <summary>
/// Represents the blog configuration.
/// </summary>
public class Blog : IConfig
{
    public Blog()
    {
    }

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public string Identifier { get; } = "Blog";

    /// <inheritdoc />
    public string Directory { get; } = "Blog";

    /// <inheritdoc />
    public string TargetPage { get; set; } = "Blog";

    /// <summary>
    /// Gets or sets the maximum amount of articles that can be displayed.
    /// </summary>
    public int DisplayLimit { get; set; } = 10;
}
