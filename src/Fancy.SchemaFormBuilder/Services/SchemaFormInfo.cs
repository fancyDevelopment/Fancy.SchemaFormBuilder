using System;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Object with schema and form information about a type.
    /// </summary>
    public class SchemaFormInfo
    {
        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public JObject Schema { get; set; }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public JContainer Form { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; set; }
    }
}
