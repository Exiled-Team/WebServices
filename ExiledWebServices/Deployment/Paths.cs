namespace ExiledWebServices.Deployment;

/// <summary>
/// Provides paths used in the application.
/// </summary>
public static class Paths
{
    /// <summary>
    /// Gets the path to the configurations directory.
    /// </summary>
    public static string Configs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");

    /// <summary>
    /// Gets the path to the articles directory.
    /// </summary>
    public static string Articles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Articles");

    /// <summary>
    /// Gets the full path to a configuration file based on the provided path.
    /// </summary>
    /// <param name="path">The relative path to the configuration file.</param>
    /// <returns>The full path to the configuration file.</returns>
    public static string GetConfigPath(string path) => Path.Combine(Configs, path);

    /// <summary>
    /// Gets the full path to a configuration file based on the provided configuration object.
    /// </summary>
    /// <param name="config">The configuration object.</param>
    /// <returns>The full path to the configuration file.</returns>
    public static string GetConfigPath(IConfig config) => Path.Combine(
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs"), Path.Combine(config.Directory, config.Identifier.SanitizeConfig()));
}