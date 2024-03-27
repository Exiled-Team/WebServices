using System.ComponentModel;
using YamlDotNet.Core;

namespace ExiledWebServices.Deployment.Validators;

using System;
using YamlDotNet.Serialization;

/// <summary>
/// Source: https://dotnetfiddle.net/8M6iIE.
/// </summary>
public sealed class CommentsPropertyDescriptor : IPropertyDescriptor
{
    private readonly IPropertyDescriptor _baseDescriptor;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentsPropertyDescriptor"/> class.
    /// </summary>
    /// <param name="baseDescriptor">The base descriptor instance.</param>
    public CommentsPropertyDescriptor(IPropertyDescriptor baseDescriptor)
    {
        this._baseDescriptor = baseDescriptor;
        Name = baseDescriptor.Name;
    }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public string Name { get; set; }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public Type Type => _baseDescriptor.Type;

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public Type TypeOverride
    {
        get => _baseDescriptor.TypeOverride;
        set => _baseDescriptor.TypeOverride = value;
    }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public int Order { get; set; }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public ScalarStyle ScalarStyle
    {
        get => _baseDescriptor.ScalarStyle;
        set => _baseDescriptor.ScalarStyle = value;
    }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public bool CanWrite => _baseDescriptor.CanWrite;

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public void Write(object target, object value)
    {
        _baseDescriptor.Write(target, value);
    }

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public T GetCustomAttribute<T>()
        where T : Attribute => _baseDescriptor.GetCustomAttribute<T>();

    /// <inheritdoc cref="IPropertyDescriptor"/>
    public IObjectDescriptor Read(object target)
    {
        DescriptionAttribute description = _baseDescriptor.GetCustomAttribute<DescriptionAttribute>();
        return description is not null
            ? new CommentsObjectDescriptor(_baseDescriptor.Read(target), description.Description)
            : _baseDescriptor.Read(target);
    }
}