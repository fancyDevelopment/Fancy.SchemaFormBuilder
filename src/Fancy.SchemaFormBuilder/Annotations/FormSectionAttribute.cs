using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// An attribute to control the hierarchy of the form layout.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FormSectionAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSectionAttribute"/> class.
        /// </summary>
        /// <param name="hierarchyPath">The hierarchy path.</param>
        public FormSectionAttribute(string hierarchyPath)
        {
            this.HierarchyPath = hierarchyPath;
        }

        /// <summary>
        /// Gets or sets the hierarchy path.
        /// </summary>
        /// <remarks>
        /// The hierarchy path consists of names for the singe layers in the hierarchy separated with a dot. 
        /// </remarks>
        /// <value>
        /// The hierarchy path.
        /// </value>
        public string HierarchyPath { get; set; }

        /// <summary>
        /// Gets or sets the type of the section.
        /// </summary>
        /// <value>
        /// The type of the section.
        /// </value>
        public SectionType SectionType { get; set; }

        /// <summary>
        /// Gets or sets the title of the section.
        /// </summary>
        /// <remarks>
        /// Title is not shown always, for example if you choose "section" as type.
        /// </remarks>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}
