using System.ComponentModel.DataAnnotations;
using YamlDotNet.Core;

namespace ExiledWebServices.Deployment.Validators;

using System;
using YamlDotNet.Serialization;

/// <summary>
/// Basic configs validation.
/// </summary>
public sealed class ValidatingNodeDeserializer : INodeDeserializer
{
    private readonly INodeDeserializer _nodeDeserializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatingNodeDeserializer"/> class.
    /// </summary>
    /// <param name="nodeDeserializer">The node deserializer instance.</param>
    public ValidatingNodeDeserializer(INodeDeserializer nodeDeserializer)
    {
        this._nodeDeserializer = nodeDeserializer;
    }

    /// <inheritdoc cref="INodeDeserializer"/>
    public bool Deserialize(IParser parser, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
    {
        try
        {
            if (_nodeDeserializer.Deserialize(parser, expectedType, nestedObjectDeserializer, out value))
            {
                Validator.ValidateObject(value, new ValidationContext(value, null, null), true);

                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            value = null;
            return false;
        }
    }
}