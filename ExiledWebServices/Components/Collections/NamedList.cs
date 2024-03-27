using ExiledWebServices.Components.Interfaces;

namespace ExiledWebServices.Components.Collections
{
    /// <summary>
    /// Represents a service for managing lists of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class NamedList<T> : INamedObject
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