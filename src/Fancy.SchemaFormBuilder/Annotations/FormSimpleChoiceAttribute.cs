using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Provides allowed values for a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormSimpleChoiceAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSimpleChoiceAttribute"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public FormSimpleChoiceAttribute(params string[] values)
        {
            Values = values;
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public string[] Values { get; set; }
    }
}
