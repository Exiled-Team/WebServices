using ExiledWebServices.Components.Interfaces;

namespace ExiledWebServices.Components.Cards;

/// <summary>
/// Represents an article card.
/// </summary>
public class ArticleCard : INamedObject, IRefObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleCard"/> class.
    /// </summary>
    public ArticleCard()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleCard"/> class with specified parameters.
    /// </summary>
    /// <param name="name">The name of the card.</param>
    /// <param name="href">The href link.</param>
    /// <param name="title">The title of the card.</param>
    /// <param name="subtitle">The subtitle of the card.</param>
    /// <param name="icon">The icon of the card.</param>
    /// <param name="tags">The tags associated with the card.</param>
    public ArticleCard(string name, string href, HtmlText title, HtmlText subtitle, string icon = "", params SerializableIcon[] tags)
    {
        Name = name;
        Href = href;
        Icon = new(icon);
        Tags = tags.ToList();
        Title = title;
        Subtitle = subtitle;
    }

    /// <summary>
    /// Gets or sets the name of the card.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the href link of the card.
    /// </summary>
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the icon of the card.
    /// </summary>
    public SerializableIcon Icon { get; set; }

    /// <summary>
    /// Gets or sets the list of tags associated with the card.
    /// </summary>
    public List<SerializableIcon>? Tags { get; set; }

    /// <summary>
    /// Gets or sets the title of the card.
    /// </summary>
    public HtmlText Title { get; set; }

    /// <summary>
    /// Gets or sets the subtitle of the card.
    /// </summary>
    public HtmlText Subtitle { get; set; }
}