namespace ExiledWebServices.Deployment.Validators;

using System;
using System.Collections.Generic;
using System.Linq;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

/// <summary>
/// Source: https://dotnetfiddle.net/8M6iIE.
/// </summary>
public sealed class CommentGatheringTypeInspector : TypeInspectorSkeleton
{
    private readonly ITypeInspector _innerTypeDescriptor;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentGatheringTypeInspector"/> class.
    /// </summary>
    /// <param name="innerTypeDescriptor">The inner type description instance.</param>
    public CommentGatheringTypeInspector(ITypeInspector innerTypeDescriptor)
    {
        this._innerTypeDescriptor = innerTypeDescriptor ?? throw new ArgumentNullException("innerTypeDescriptor");
    }

    /// <inheritdoc/>
    public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
    {
        return _innerTypeDescriptor
            .GetProperties(type, container)
            .Select(descriptor => new CommentsPropertyDescriptor(descriptor));
    }
}