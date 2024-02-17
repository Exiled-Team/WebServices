using System.Web;
using ExiledWebServices.Components.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MudBlazor;
using YamlDotNet.Serialization;

namespace ExiledWebServices.Components.Core
{
    /// <summary>
    /// Represents a component for rendering HTML content in a Blazor application.
    /// </summary>
    public class HtmlText
    {
        private string text;
        private RenderFragment fragment;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlText"/> class.
        /// </summary>
        public HtmlText()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlText"/> class with the specified text and optional tags.
        /// </summary>
        /// <param name="txt">The HTML content.</param>
        /// <param name="tags">Optional tags to surround the HTML content.</param>
        public HtmlText(string txt, params string[] tags)
        {
            Text = txt;

            if (tags is not null)
                Tags = tags;
        }

        /// <summary>
        /// Gets or sets the HTML content.
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                text = value;
                EncodedText = builder =>
                {
                    EncodeContent(builder);
                };
            }
        }

        /// <summary>
        /// Gets or sets the tags to surround the HTML content.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the encoded HTML content.
        /// </summary>
        [YamlIgnore]
        public RenderFragment EncodedText
        {
            get => fragment ??= builder =>
            {
                EncodeContent(builder);
            };
            set => fragment = value;
        }

        /// <summary>
        /// Implicit conversion from <see cref="HtmlText"/> to <see cref="string"/>.
        /// </summary>
        public static implicit operator string(HtmlText text) => text.Text;

        /// <summary>
        /// Implicit conversion from <see cref="string"/> to <see cref="HtmlText"/>.
        /// </summary>
        public static implicit operator HtmlText(string text) => new(text);

        /// <summary>
        /// Encodes the HTML content and renders it using the specified <see cref="RenderTreeBuilder"/>.
        /// </summary>
        public virtual void EncodeContent(RenderTreeBuilder builder)
        {
            string result = Text;

            if (Tags is not null)
            {
                foreach (string tag in Tags)
                    result = result.Insert(0, $"<{tag}>").Insert(result.Length - 1, $"</{tag}>");
            }

            Text = result;
            builder.AddMarkupContent(0, Text);
        }
    }
}
