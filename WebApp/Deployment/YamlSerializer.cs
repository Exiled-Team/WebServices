using WebApp.Deployment.Validators;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;
using UnderscoredNamingConvention = YamlDotNet.Serialization.NamingConventions.UnderscoredNamingConvention;

namespace WebApp.Deployment;

/// <summary>
/// Provides methods for serializing and deserializing YAML data.
/// </summary>
public static class YamlSerializer
{
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .WithNodeDeserializer(inner => new ValidatingNodeDeserializer(inner), deserializer =>
            deserializer.InsteadOf<ObjectNodeDeserializer>())
        .IgnoreFields()
        .IgnoreUnmatchedProperties()
        .Build();

    private static readonly ISerializer Serializer = new SerializerBuilder()
        .WithEventEmitter(eventEmitter => new TypeAssigningEventEmitter(eventEmitter))
        .WithTypeInspector(inner => new CommentGatheringTypeInspector(inner))
        .WithEmissionPhaseObjectGraphVisitor(args => new CommentsObjectGraphVisitor(args.InnerVisitor))
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .IgnoreFields()
        .DisableAliases()
        .Build();

    /// <summary>
    /// Gets the service serializer instance.
    /// </summary>
    public static ISerializer ServiceSerializer => Serializer;

    /// <summary>
    /// Gets the service deserializer instance.
    /// </summary>
    public static IDeserializer ServiceDeserializer => Deserializer;

    /// <summary>
    /// Serializes the specified object to YAML format and writes it to the specified file path.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="filePath">The file path where the YAML data will be written.</param>
    public static void Serialize<T>(T obj, string filePath)
        where T : class
    {

        string yaml = ServiceSerializer.Serialize(obj, obj.GetType());

        using StreamWriter writer = new(filePath);
        writer.Write(yaml);
    }

    /// <summary>
    /// Deserializes YAML data from the specified file path and returns the deserialized object.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="filePath">The file path from which to deserialize YAML data.</param>
    /// <param name="type">The type to deserialize to (optional).</param>
    /// <returns>The deserialized object.</returns>
    public static T Deserialize<T>(string filePath, Type type = null)
        where T : class
    {
        if (!filePath.Contains(".yml"))
            filePath += ".yml";

        string yaml = File.ReadAllText(filePath);
        return type is not null ? ServiceDeserializer.Deserialize(yaml, type) as T : ServiceDeserializer.Deserialize<T>(yaml);
    }
}
