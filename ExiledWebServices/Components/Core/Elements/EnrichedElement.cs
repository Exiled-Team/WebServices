using ExiledWebServices.Components.Core.Interfaces;
using MudBlazor;
using System;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents an enriched list item with additional properties such as title, subtitle, publish date, link, and image.
    /// </summary>
    public class EnrichedElement
    {
        /// <summary>
        /// Gets or sets the title of the enriched item.
        /// </summary>
        public HtmlText Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle of the enriched item.
        /// </summary>
        public HtmlText Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the publish date of the enriched item.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the link associated with the enriched item.
        /// </summary>
        public Link Link { get; set; }

        /// <summary>
        /// Gets or sets the image associated with the enriched item.
        /// </summary>
        public Image Image { get; set; }
    }
}