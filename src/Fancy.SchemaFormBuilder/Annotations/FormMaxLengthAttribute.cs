using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to declare the maximum length of a string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class FormMaxLengthAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormMaxLengthAttribute" /> class.
        /// </summary>
        /// <param name="length">The length.</param>
        public FormMaxLengthAttribute(uint length)
        {
            Length = length;
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public uint Length { get; set; }
    }
}
