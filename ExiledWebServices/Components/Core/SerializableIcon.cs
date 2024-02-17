using ExiledWebServices.Components.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Components.Core;

/// <summary>
/// Represents a serializable icon that inherits from MudIcon and implements IRefObject.
/// </summary>
public class SerializableIcon : MudIcon, IRefObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SerializableIcon"/> class.
    /// </summary>
    public SerializableIcon()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SerializableIcon"/> class with the specified class and href.
    /// </summary>
    /// <param name="class">The class of the icon.</param>
    /// <param name="href">The href of the icon.</param>
    public SerializableIcon(string @class, string href = "")
    {
        Class = @class;
        Href = href;
    }

    /// <inheritdoc />
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the icon to be used can either be svg paths for font icons.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Behavior)]
    public new string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the title of the icon used for accessibility.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Behavior)]
    public new string? Title { get; set; }

    /// <summary>
    /// Gets a value indicating the size of the icon.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Appearance)]
    public new Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets a value indicating the color of the component. It supports the theme colors.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Appearance)]
    public new Color Color { get; set; } = Color.Inherit;

    /// <summary>
    /// Gets a value indicating the viewbox size of an svg element.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Behavior)]
    public new string ViewBox { get; set; } = "0 0 24 24";

    /// <summary>
    /// Gets a value indicating the child content of the component.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.Icon.Behavior)]
    public new RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the user styles, applied on top of the component's own classes and styles.
    /// </summary>
    [YamlIgnore]
    [Parameter]
    [Category(CategoryTypes.ComponentBase.Common)]
    public new string? Style { get; set; }

    /// <summary>
    /// Gets or sets the user attributes that don't match any of the component's parameters.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    [Category(CategoryTypes.ComponentBase.Common)]
    [YamlIgnore]
    public new Dictionary<string, object?> UserAttributes { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Gets a value indicating the ID of the component.
    /// </summary>
    [YamlIgnore]
    public new string FieldId => (UserAttributes?.ContainsKey("id") == true
        ? UserAttributes["id"]?.ToString() ?? $"mudinput-{Guid.NewGuid()}"
        : $"mudinput-{Guid.NewGuid()}");
}