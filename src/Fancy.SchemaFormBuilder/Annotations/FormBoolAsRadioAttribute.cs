using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Provides answer values for a boolean property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormBoolAsRadioAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormBoolAsRadioAttribute"/> class.
        /// </summary>
        /// <param name="yesTitle">The yes title.</param>
        /// <param name="noTitle">The no title.</param>
        public FormBoolAsRadioAttribute(string yesTitle, string noTitle)
        {
            YesTitle = yesTitle;
            NoTitle = noTitle;
        }

        /// <summary>
        /// Gets or sets the yes title.
        /// </summary>
        /// <value>
        /// The yes title.
        /// </value>
        public string YesTitle { get; set; }

        /// <summary>
        /// Gets or sets the no title.
        /// </summary>
        /// <value>
        /// The no title.
        /// </value>
        public string NoTitle { get; set; }
    }
}
