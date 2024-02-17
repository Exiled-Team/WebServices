using ExiledWebServices.Components.Core.Interfaces;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents a cover element.
    /// </summary>
    public class CoverElement : IRefObject
    {
        /// <summary>
        /// Gets or sets the title of the cover element.
        /// </summary>
        public HtmlText Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle of the cover element.
        /// </summary>
        public HtmlText Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink reference associated with the cover element.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the image of the cover element.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the tag icon of the cover element.
        /// </summary>
        public SerializableIcon Tag { get; set; }

        /// <summary>
        /// Gets or sets the notification message for reading the cover element.
        /// </summary>
        public string NotifyReading { get; set; }
    }
}