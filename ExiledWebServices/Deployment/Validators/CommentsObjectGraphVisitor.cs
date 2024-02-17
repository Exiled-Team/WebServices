using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectGraphVisitors;

namespace ExiledWebServices.Deployment.Validators;

using System;
using System.Collections.Generic;
using System.Linq;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

/// <summary>
/// Source: https://dotnetfiddle.net/8M6iIE.
/// </summary>
public sealed class CommentsObjectGraphVisitor : ChainedObjectGraphVisitor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentsObjectGraphVisitor"/> class.
    /// </summary>
    /// <param name="nextVisitor">The next visitor instance.</param>
    public CommentsObjectGraphVisitor(IObjectGraphVisitor<IEmitter> nextVisitor)
        : base(nextVisitor)
    {
    }

    /// <inheritdoc/>
    public override bool EnterMapping(IPropertyDescriptor key, IObjectDescriptor value, IEmitter context)
    {
        if (value is CommentsObjectDescriptor commentsDescriptor && commentsDescriptor.Comment is not null)
        {
            foreach (string subComment in commentsDescriptor.Comment.Split('\n'))
            {
                context.Emit(new Comment(subComment, false));
            }
        }

        return base.EnterMapping(key, value, context);
    }
}