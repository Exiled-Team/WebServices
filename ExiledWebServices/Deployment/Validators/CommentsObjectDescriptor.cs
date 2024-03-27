using YamlDotNet.Core;

namespace ExiledWebServices.Deployment.Validators;

using System;
using YamlDotNet.Serialization;

/// <summary>
/// Source: https://dotnetfiddle.net/8M6iIE.
/// </summary>
public sealed class CommentsObjectDescriptor : IObjectDescriptor
{
    private readonly IObjectDescriptor _innerDescriptor;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentsObjectDescriptor"/> class.
    /// </summary>
    /// <param name="innerDescriptor">The inner descriptor instance.</param>
    /// <param name="comment">The comment to be written.</param>
    public CommentsObjectDescriptor(IObjectDescriptor innerDescriptor, string comment)
    {
        this._innerDescriptor = innerDescriptor;
        Comment = comment;
    }

    /// <summary>
    /// Gets the comment to be written.
    /// </summary>
    public string Comment { get; private set; }

    /// <inheritdoc cref="IObjectDescriptor" />
    public object Value => _innerDescriptor.Value;

    /// <inheritdoc cref="IObjectDescriptor" />
    public Type Type => _innerDescriptor.Type;

    /// <inheritdoc cref="IObjectDescriptor" />
    public Type StaticType => _innerDescriptor.StaticType;

    /// <inheritdoc cref="IObjectDescriptor" />
    public ScalarStyle ScalarStyle => _innerDescriptor.ScalarStyle;
}