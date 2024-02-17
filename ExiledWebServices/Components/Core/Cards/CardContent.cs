namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents the content of a card.
    /// </summary>
    public class CardContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardContent"/> class.
        /// </summary>
        public CardContent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardContent"/> class with the specified title and subtitle.
        /// </summary>
        /// <param name="title">The title of the card content.</param>
        /// <param name="subtitle">The subtitle of the card content.</param>
        public CardContent(HtmlText title, HtmlText subtitle)
        {
            Title = title;
            Subtitle = subtitle;
        }

        /// <summary>
        /// Gets or sets the title of the card content.
        /// </summary>
        public HtmlText Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle of the card content.
        /// </summary>
        public HtmlText Subtitle { get; set; }
    }
}