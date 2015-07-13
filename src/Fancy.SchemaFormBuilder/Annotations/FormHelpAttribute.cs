using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to declare help information on a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FormHelpAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormHelpAttribute"/> class.
        /// </summary>
        /// <param name="helpText">The help text.</param>
        public FormHelpAttribute(string helpText)
        {
            this.HelpText = helpText;
        }

        /// <summary>
        /// Gets or sets the help text.
        /// </summary>
        /// <value>
        /// The help text.
        /// </value>
        public string HelpText { get; set; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <remarks>
        /// This property need to be a valid JavaScript expression which uses the name of the 
        /// class and can then navigate to the properties of the class.
        /// </remarks>
        /// <value>
        /// The condition.
        /// </value>
        public string Condition { get; set; }

        /// <summary>
        /// Gets or sets the type of the help.
        /// </summary>
        /// <value>
        /// The type of the help.
        /// </value>
        public HelpType HelpType { get; set; }
    }
}
