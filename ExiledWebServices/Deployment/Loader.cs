using System.Reflection;
using System.Xml.Schema;
using ExiledWebServices.Components.Configs;
using ExiledWebServices.Components.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Deployment;

/// <summary>
/// Class for loading configurations.
/// </summary>
public class Loader
{
    /// <summary>
    /// Gets the serializer for writing YAML data.
    /// </summary>
    public static ISerializer Serializer => YamlSerializer.ServiceSerializer;

    /// <summary>
    /// Gets the deserializer for reading YAML data.
    /// </summary>
    public static IDeserializer Deserializer => YamlSerializer.ServiceDeserializer;

    /// <summary>
    /// Gets a set of loaded configurations.
    /// </summary>
    public static List<object> LoadedConfigs { get; } = new();

    /// <summary>
    /// Gets the configuration object for the specified target page.
    /// </summary>
    /// <param name="targetPage">The target page.</param>
    /// <returns>The configuration object.</returns>
    public static object GetConfig(string targetPage) => LoadedConfigs.FirstOrDefault(c =>
        c is IConfig cfg && cfg.TargetPage.Equals(targetPage, StringComparison.CurrentCultureIgnoreCase));

    /// <summary>
    /// Gets the configuration object of type <typeparamref name="T"/> for the specified target page.
    /// </summary>
    /// <typeparam name="T">The type of the configuration object.</typeparam>
    /// <returns>The configuration object of type <typeparamref name="T"/>.</returns>
    public static T GetConfig<T>()
        where T : IConfig => (T)LoadedConfigs.FirstOrDefault(c =>
        c is T cfg && cfg.IsEnabled && c.GetType() == typeof(T));

    /// <summary>
    /// Gets the configuration object of type <typeparamref name="T"/> for the specified target page.
    /// </summary>
    /// <typeparam name="T">The type of the configuration object.</typeparam>
    /// <param name="targetPage">The target page.</param>
    /// <returns>The configuration object of type <typeparamref name="T"/>.</returns>
    public static T GetConfig<T>(string targetPage = "")
        where T : IConfig => (T)LoadedConfigs.FirstOrDefault(c =>
        c is T cfg && cfg.IsEnabled && c.GetType() == typeof(T) && cfg.TargetPage.Equals(targetPage, StringComparison.CurrentCultureIgnoreCase));

    /// <summary>
    /// Loads all configurations.
    /// </summary>
    public static void LoadConfigs()
    {
        List<object> csf = LoadedConfigs;
        Console.WriteLine(LoadedConfigs);

        Directory.CreateDirectory(Paths.Configs);

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!typeof(IConfig).IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                continue;

            object @object = Activator.CreateInstance(type);

            if (@object is not IConfig config || LoadedConfigs.Any(val => val is IConfig cfg && Paths.GetConfigPath(cfg) == Paths.GetConfigPath(config)))
                continue;

            if (File.Exists(Paths.GetConfigPath(config)))
            {
                object deserializedObject = YamlSerializer.Deserialize<object>(Paths.GetConfigPath(config), config.GetType());
                LoadedConfigs.Add(deserializedObject);
                continue;
            }

            Directory.CreateDirectory(Paths.GetConfigPath(config.Directory));

            LoadedConfigs.Add(config);
            YamlSerializer.Serialize(config, Paths.GetConfigPath(config));
        }
    }

    /// <summary>
    /// Gets configuration file paths from the specified directory.
    /// </summary>
    /// <param name="directoryPath">The directory path.</param>
    /// <returns>A list of configuration file paths.</returns>
    public static List<string> GetConfigsFromDirectory(string directoryPath)
    {
        List<string> configs = new List<string>();

        // Get paths of YAML files in the directory
        foreach (string config in Directory.GetFiles(directoryPath, "*.yml"))
            configs.Add(config);

        // Get paths of YAML files in subdirectories
        foreach (string subDir in Directory.GetDirectories(directoryPath))
            configs.AddRange(GetConfigsFromDirectory(subDir));

        return configs;
    }
}