using System.ComponentModel.DataAnnotations;
using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectGraphVisitors;

namespace ExiledWebServices.Deployment.Validators;

using System;
using System.Collections.Generic;
using System.Linq;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

/// <summary>
/// Basic configs validation.
/// </summary>
public sealed class ValidatingNodeDeserializer : INodeDeserializer
{
    private readonly INodeDeserializer nodeDeserializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatingNodeDeserializer"/> class.
    /// </summary>
    /// <param name="nodeDeserializer">The node deserializer instance.</param>
    public ValidatingNodeDeserializer(INodeDeserializer nodeDeserializer)
    {
        this.nodeDeserializer = nodeDeserializer;
    }

    /// <inheritdoc cref="INodeDeserializer"/>
    public bool Deserialize(IParser parser, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
    {
        try
        {
            if (nodeDeserializer.Deserialize(parser, expectedType, nestedObjectDeserializer, out value))
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