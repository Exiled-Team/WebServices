using ExiledWebServices.Components.Core.Interfaces;
using ExiledWebServices.Deployment;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Service for managing articles loaded from Markdown files.
    /// </summary>
    public class ArticleService : IArticleService
    {
        private static ArticleService instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ArticleService"/>.
        /// </summary>
        public static ArticleService Instance => instance ??= new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleService"/> class.
        /// </summary>
        public ArticleService()
        {
            instance = this;

            foreach (string md in GetMarkdownFilePaths(Paths.Articles))
                Articles.Add(MarkdownArticle.FromMarkdownFile(md));
        }

        /// <summary>
        /// Gets the list of Markdown file paths in the specified directory.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns>The list of Markdown file paths.</returns>
        public List<string> GetMarkdownFilePaths(string directoryPath)
        {
            List<string> markdownFilePaths = new List<string>();
            string[] filePaths = Directory.GetFiles(directoryPath, "*.md", SearchOption.AllDirectories);
            markdownFilePaths.AddRange(filePaths.Select(filePath => Path.GetFullPath(filePath)));
            return markdownFilePaths;
        }

        /// <summary>
        /// Gets the list of loaded Markdown articles.
        /// </summary>
        public List<MarkdownArticle> Articles { get; } = new();

        /// <summary>
        /// Gets the Markdown article with the specified name.
        /// </summary>
        /// <param name="name">The name of the article.</param>
        /// <returns>The Markdown article with the specified name, or null if not found.</returns>
        public MarkdownArticle GetArticleByName(string name) => Articles.FirstOrDefault(article => article.Name == name);
    }
}
