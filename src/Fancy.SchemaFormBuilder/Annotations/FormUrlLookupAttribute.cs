using System;

using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Provides a lookup type for a property which values come from a lookup url.
    /// </summary>
    /// <remarks>
    /// The lookup url to the specified lookup type is retrieved by using the <see cref="IUrlLookupProvider"/> interface. An implementation
    /// of this class has to return an url which provides the possible values as title map. 
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormUrlLookupAttribute : FormAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormUrlLookupAttribute"/> class.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        public FormUrlLookupAttribute(string lookupType)
        {
            LookupType = lookupType;
        }

        /// <summary>
        /// Gets the type of the lookup.
        /// </summary>
        /// <value>
        /// The type of the lookup.
        /// </value>
        public string LookupType { get; private set; }
    }
}
