using ExiledWebServices.Components.Core.Interfaces;
using MudBlazor;

namespace ExiledWebServices.Components.Core
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