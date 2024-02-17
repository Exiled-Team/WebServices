namespace ExiledWebServices.Deployment;

/// <summary>
/// Provides extension methods for configuration-related operations.
/// </summary>
public static class ConfigExtensions
{
    /// <summary>
    /// Gets the absolute path of the configuration file.
    /// </summary>
    /// <param name="config">The configuration.</param>
    /// <returns>The absolute path of the configuration file.</returns>
    public static string GetAbsolutePath(this IConfig config) =>
        Path.Combine(config.Directory.SanitizeDirectory(), config.Identifier.SanitizeConfig());

    /// <summary>
    /// Sanitizes the directory path by ensuring it starts and ends with a forward slash.
    /// </summary>
    /// <param name="directory">The directory path to sanitize.</param>
    /// <returns>The sanitized directory path.</returns>
    public static string SanitizeDirectory(this string directory)
    {
        string sanitizedDir = directory;

        if (sanitizedDir[0] != '/')
            sanitizedDir = "/" + sanitizedDir;

        if (sanitizedDir[sanitizedDir.Length - 1] != '/')
            sanitizedDir += '/';

        return sanitizedDir;
    }

    /// <summary>
    /// Sanitizes the configuration name by ensuring it ends with ".yml".
    /// </summary>
    /// <param name="config">The configuration name to sanitize.</param>
    /// <returns>The sanitized configuration name.</returns>
    public static string SanitizeConfig(this IConfig config)
    {
        string sanitizedName = config.Identifier;

        if (!sanitizedName.Contains(".yml"))
            sanitizedName += ".yml";

        return sanitizedName;
    }

    /// <summary>
    /// Sanitizes the configuration name by ensuring it ends with ".yml".
    /// </summary>
    /// <param name="config">The configuration name to sanitize.</param>
    /// <returns>The sanitized configuration name.</returns>
    public static string SanitizeConfig(this string config)
    {
        string sanitizedName = config;

        if (!sanitizedName.Contains(".yml"))
            sanitizedName += ".yml";

        return sanitizedName;
    }
}
