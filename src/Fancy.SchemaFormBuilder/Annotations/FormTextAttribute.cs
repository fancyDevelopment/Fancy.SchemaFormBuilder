using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to add text to the form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FormTextAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTextAttribute"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public FormTextAttribute(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
    }
}
