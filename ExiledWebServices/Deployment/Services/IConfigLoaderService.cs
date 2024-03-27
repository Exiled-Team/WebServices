namespace ExiledWebServices.Deployment.Services;

public interface IConfigLoaderService
{
    /// <summary>
    /// Loads all configurations.
    /// </summary>
    /// <param name="targetPage">The specified target page.</param>
    void LoadConfigs(string targetPage = "");

    /// <summary>
    /// Gets a set of loaded configurations.
    /// </summary>
    List<object> LoadedConfigs { get; }
    
    /// <summary>
    /// Gets the configuration object for the specified target page.
    /// </summary>
    /// <param name="targetPage">The target page.</param>
    /// <returns>The configuration object.</returns>
    object GetConfig(string targetPage);

    /// <summary>
    /// Gets the configuration object of type <typeparamref name="T"/> for the specified target page.
    /// </summary>
    /// <typeparam name="T">The type of the configuration object.</typeparam>
    /// <returns>The configuration object of type <typeparamref name="T"/>.</returns>
    T GetConfig<T>() where T : IConfig;

    /// <summary>
    /// Gets the configuration object of type <typeparamref name="T"/> for the specified target page.
    /// </summary>
    /// <typeparam name="T">The type of the configuration object.</typeparam>
    /// <param name="targetPage">The target page.</param>
    /// <returns>The configuration object of type <typeparamref name="T"/>.</returns>
    T GetConfig<T>(string targetPage = "") where T : IConfig;
}