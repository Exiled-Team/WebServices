using ExiledWebServices.Components.Interfaces;
using MudBlazor;

namespace ExiledWebServices.Components
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