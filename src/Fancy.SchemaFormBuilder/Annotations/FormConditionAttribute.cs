using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Defines a condition for a form element.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormConditionAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormConditionAttribute"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        public FormConditionAttribute(string condition)
        {
            Condition = condition;
        }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>
        /// The condition.
        /// </value>
        public string Condition { get; set; }
    }
}