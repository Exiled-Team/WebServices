using WebApp.Components.Interfaces;
using MudBlazor;

namespace WebApp.Components
{
    /// <summary>
    /// Represents a button component that inherits from MudButton and implements INamedObject.
    /// </summary>
    public class Button : MudButton, INamedObject
    {
        /// <inheritdoc />
        public string Name { get; set; }
    }
}