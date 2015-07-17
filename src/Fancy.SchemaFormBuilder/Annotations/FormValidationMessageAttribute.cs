using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to add a validation message to a property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormValidationMessageAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormValidationMessageAttribute" /> class.
        /// </summary>
        /// <param name="messageText">The validation message text.</param>
        public FormValidationMessageAttribute(string messageText)
        {
            this.MessageText = messageText;
        }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string MessageText { get; set; }
    }
}
