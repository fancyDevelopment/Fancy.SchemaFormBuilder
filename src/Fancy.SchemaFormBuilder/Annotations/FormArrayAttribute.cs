using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Marks an form array.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormArrayAttribute : FormAttribute
    {
        /// <summary>
        /// Gets or sets the add button title.
        /// </summary>
        /// <value>
        /// The add button title.
        /// </value>
        public string AddButtonTitle { get; set; }

        /// <summary>
        /// Gets or sets the minimum items count.
        /// </summary>
        /// <value>
        /// The minimum items.
        /// </value>
        public int MinItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum items count.
        /// </summary>
        /// <value>
        /// The maximum items.
        /// </value>
        public int MaxItems { get; set; }
    }
}