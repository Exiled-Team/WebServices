using ExiledWebServices.Components.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents an image component that inherits from MudImage and implements INamedObject and IRefObject.
    /// </summary>
    public class Image : MudImage, INamedObject, IRefObject
    {
        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the href of the image.
        /// </summary>
        public string Href { get; set; }
    }
}