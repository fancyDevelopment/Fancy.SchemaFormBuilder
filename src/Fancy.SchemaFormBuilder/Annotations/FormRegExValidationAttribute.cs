using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to specify a regular expression to a property to validate it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormRegExValidationAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRegExValidationAttribute"/> class.
        /// </summary>
        /// <param name="regEx">The regular expression.</param>
        public FormRegExValidationAttribute(string regEx)
        {
            this.RegEx = regEx;
        }

        /// <summary>
        /// Gets or sets the regular expression.
        /// </summary>
        /// <value>
        /// The regular expression.
        /// </value>
        public string RegEx { get; set; }
    }
}
