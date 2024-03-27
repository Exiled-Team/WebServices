namespace WebApp.Deployment.Validators;

using System.Collections.Generic;
using YamlDotNet.Serialization;

/// <inheritdoc cref="YamlDotNet.Serialization.NamingConventions.UnderscoredNamingConvention"/>
public class UnderscoredNamingConvention : INamingConvention
{
    /// <inheritdoc cref="YamlDotNet.Serialization.NamingConventions.UnderscoredNamingConvention.Instance"/>
    public static UnderscoredNamingConvention Instance { get; } = new();

    /// <summary>
    /// Gets the list.
    /// </summary>
    public List<object> Properties { get; } = new();

    public string Reverse(string value) => value.ToPascalCase();

    /// <inheritdoc/>
    public string Apply(string value)
    {
        string newValue = value.ToSnakeCase();
        Properties.Add(newValue);
        return newValue;
    }
}