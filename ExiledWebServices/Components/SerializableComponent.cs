using Microsoft.AspNetCore.Components;
using MudBlazor;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Components;

/// <summary>
/// The serializable <see cref="MudComponentBase"/>.
/// </summary>
public class SerializableComponent : MudComponentBase
{
    /// <summary>
    /// The higher the number, the heavier the drop-shadow. 0 for no shadow.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Card.Appearance)]
    public new int Elevation { set; get; } = 1;

    /// <summary>
    /// If true, border-radius is set to 0.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Card.Appearance)]
    public new bool Square { get; set; }

    /// <summary>
    /// If true, card will be outlined.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Card.Appearance)]
    public new bool Outlined { get; set; }

    /// <summary>
    /// Child content of the component.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Card.Behavior)]
    public new RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// User class names, separated by space.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.ComponentBase.Common)]
    public new string? Class { get; set; }

    /// <summary>
    /// User styles, applied on top of the component's own classes and styles.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.ComponentBase.Common)]
    public new string? Style { get; set; }

    /// <summary>
    /// Use Tag to attach any user data object to the component for your convenience.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.ComponentBase.Common)]
    public new object? Tag { get; set; }

    /// <summary>
    /// UserAttributes carries all attributes you add to the component that don't match any of its parameters.
    /// They will be splatted onto the underlying HTML tag.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    [Category(CategoryTypes.ComponentBase.Common)]
    [YamlIgnore]
    public new Dictionary<string, object?> UserAttributes { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// If the UserAttributes contain an ID make it accessible for WCAG labelling of input fields
    /// </summary>
    [YamlIgnore]
    public new string FieldId => (UserAttributes?.ContainsKey("id") == true
        ? UserAttributes["id"]?.ToString() ?? $"mudinput-{Guid.NewGuid()}"
        : $"mudinput-{Guid.NewGuid()}");
}