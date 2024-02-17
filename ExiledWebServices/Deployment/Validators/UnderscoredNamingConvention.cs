using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.ObjectGraphVisitors;

namespace ExiledWebServices.Deployment.Validators;

using System;
using System.Collections.Generic;
using System.Linq;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

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