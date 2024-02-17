using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;

namespace ExiledWebServices.Deployment.Validators;

/// <summary>
/// Event emitter which wraps all strings in double quotes.
/// </summary>
public class TypeAssigningEventEmitter : ChainedEventEmitter
{
    private readonly char[] multiline = new char[] { '\r', '\n', '\x85', '\x2028', '\x2029' };

    /// <inheritdoc cref="ChainedEventEmitter"/>
    public TypeAssigningEventEmitter(IEventEmitter nextEmitter)
        : base(nextEmitter)
    {
    }

    /// <inheritdoc/>
    public override void Emit(ScalarEventInfo eventInfo, IEmitter emitter)
    {
        if (eventInfo.Source.StaticType != typeof(object) && Type.GetTypeCode(eventInfo.Source.StaticType) == TypeCode.String &&
            !UnderscoredNamingConvention.Instance.Properties.Contains(eventInfo.Source.Value))
        {
            if (eventInfo.Source.Value == null || eventInfo.Source.Value.ToString().IndexOfAny(multiline) is -1)
                eventInfo.Style = ScalarStyle.Any;
            else
                eventInfo.Style = ScalarStyle.Any;
        }

        base.Emit(eventInfo, emitter);
    }
}