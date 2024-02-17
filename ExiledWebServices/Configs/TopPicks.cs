using ExiledWebServices.Components.Core;
using ExiledWebServices.Deployment;

namespace ExiledWebServices.Components.Configs;

/// <summary>
/// Represents the top-picks configuration.
/// </summary>
public class TopPicks : IConfig
{
    public TopPicks()
    {
    }

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public string Identifier { get; } = "TopPicks";

    /// <inheritdoc />
    public string Directory { get; } = "Home";

    /// <inheritdoc />
    public string TargetPage { get; set; } = "Home";

    /// <summary>
    /// Gets or sets all articles that should be displayed.
    /// </summary>
    public ListService<CoverCard> Elements { get; set; } = new()
    {
        MaxDisplayableItems = 10,
        Items = new()
        {
            new CoverCard()
            {
                Name = "Discord Integration",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "Discord Integration" },
                Content = new()
                {
                    Title = "Discord Integration",
                    Subtitle = "@Exiled-Team",
                },
            },
            new CoverCard()
            {
                Name = "CedMod",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "CedMod" },
                Content = new()
                {
                    Title = "CedMod",
                    Subtitle = "@ced777ric",
                },
            },
            new CoverCard()
            {
                Name = "Scripted Events",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "Scripted Events" },
                Content = new()
                {
                    Title = "Scripted Events",
                    Subtitle = "@thunder300",
                },
            },
            new CoverCard()
            {
                Name = "Admin Tools",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "Admin Tools" },
                Content = new()
                {
                    Title = "Admin Tools",
                    Subtitle = "@Exiled-Team",
                },
            },
            new CoverCard()
            {
                Name = "Map Editor Reborn",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "Map Editor Reborn" },
                Content = new()
                {
                    Title = "Map Editor Reborn",
                    Subtitle = "@michal78900",
                },
            },
            new CoverCard()
            {
                Name = "Common Utilities",
                Href = "#",
                Image = new() { Src = "./assets/images/background/default-plugin-bg.png", Alt = "Common Utilities" },
                Content = new()
                {
                    Title = "Common Utilities",
                    Subtitle = "@Exiled-Team",
                },
            }
        }
    };
}
