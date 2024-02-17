using ExiledWebServices.Components.Core.Interfaces;
using MudBlazor;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents a cover card.
    /// </summary>
    public class CoverCard : INamedObject, IRefObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoverCard"/> class.
        /// </summary>
        public CoverCard()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoverCard"/> class with the specified name, href, content, and image.
        /// </summary>
        /// <param name="name">The name of the cover card.</param>
        /// <param name="href">The hyperlink reference of the cover card.</param>
        /// <param name="content">The content of the cover card.</param>
        /// <param name="image">The image of the cover card.</param>
        public CoverCard(string name, string href, CardContent content, Image image)
        {
            Name = name;
            Href = href;
            Image = image;
            Content = content;
        }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the image of the cover card.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the content of the cover card.
        /// </summary>
        public CardContent Content { get; set; }
    }
}