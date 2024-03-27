using WebApp.Components.Interfaces;
using MudBlazor;

namespace WebApp.Components
{
    /// <summary>
    /// Represents a link component that inherits from MudLink and implements INamedObject.
    /// </summary>
    public class Link : MudLink, INamedObject
    {
        /// <summary>
        /// Gets or sets the name of the link.
        /// </summary>
        public string Name { get; set; }
    }
}