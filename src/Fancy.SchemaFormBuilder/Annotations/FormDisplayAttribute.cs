using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to declare a an element is shown in the form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FormDisplayAttribute : FormAttribute
    {
        /// <summary>
        /// Gets or sets the display width.
        /// </summary>
        /// <value>
        /// The display width.
        /// </value>
        public DisplayWidth DisplayWidth { get; set; }
    }
}
