using ExiledWebServices.Components.Core.Interfaces;
using MudBlazor;
using System.Collections.Generic;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents a service for managing lists of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class ListService<T> : INamedObject
        where T : class
    {
        /// <summary>
        /// Gets or sets the list of items.
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to display.
        /// </summary>
        public int MaxDisplayableItems { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }
    }
}