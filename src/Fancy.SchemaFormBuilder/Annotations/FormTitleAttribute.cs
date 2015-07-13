using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to identify required properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class)]
    public class FormTitleAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTitleAttribute"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public FormTitleAttribute(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}
