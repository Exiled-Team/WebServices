using System.Reflection;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Deployment.Services;

/// <summary>
/// Class for loading configurations.
/// </summary>
public class ConfigLoaderService : IConfigLoaderService
{
    /// <summary>
    /// Gets the serializer for writing YAML data.
    /// </summary>
    public static ISerializer Serializer => YamlSerializer.ServiceSerializer;

    /// <summary>
    /// Gets the deserializer for reading YAML data.
    /// </summary>
    public static IDeserializer Deserializer => YamlSerializer.ServiceDeserializer;

    /// <inheritdoc/>
    public List<object> LoadedConfigs { get; } = new();

    /// <inheritdoc/>
    public object GetConfig(string targetPage) => LoadedConfigs.FirstOrDefault(c => 
        c is IConfig cfg && cfg.TargetPage.Equals(targetPage, StringComparison.CurrentCultureIgnoreCase));

    /// <inheritdoc/>
    public T GetConfig<T>()
        where T : IConfig => (T)LoadedConfigs.FirstOrDefault(c => 
        c is T cfg && cfg.IsEnabled && c.GetType() == typeof(T));

    /// <inheritdoc/>
    public T GetConfig<T>(string targetPage = "")
        where T : IConfig => (T)LoadedConfigs.FirstOrDefault(c =>
        c is T { IsEnabled: true } cfg && cfg.TargetPage.Equals(targetPage, StringComparison.CurrentCultureIgnoreCase));

    /// <inheritdoc/>
    public void LoadConfigs(string targetPage = "")
    {
        Directory.CreateDirectory(Paths.Configs);

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!typeof(IConfig).IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                continue;

            object @object = Activator.CreateInstance(type);

            if (@object is not IConfig config || (!string.IsNullOrEmpty(targetPage) && config.TargetPage != targetPage) ||
                LoadedConfigs.Any(val => val is IConfig cfg && Paths.GetConfigPath(cfg) == Paths.GetConfigPath(config)))
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
    
    /// <summary>
    /// Gets a page's attribute given a file path.
    /// </summary>
    /// <param name="filePath">The page's path.</param>
    /// <returns>The given file path.</returns>
    public static string GetPageAttributeValue(string filePath)
    {
        string fileContent = File.ReadAllText(filePath);
        Match match = Regex.Match(fileContent, "@page \"(.+?)\"");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}