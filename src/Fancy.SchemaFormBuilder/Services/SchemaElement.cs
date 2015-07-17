using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Describes one element in a JSON schema.
    /// </summary>
    public class SchemaElement
    {
        /// <summary>
        /// Gets or sets the schema of the element.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public JObject Schema { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this element is required.
        /// </summary>
        /// <value>
        /// <c>true</c> if this element is required; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets the existing schema or creates a new empty schema object if it does not exist yet.
        /// </summary>
        /// <returns>The schema JSON object.</returns>
        public JObject GetOrCreateSchemaObject()
        {
            if (this.Schema == null)
            {
                this.Schema = new JObject();
            }

            return this.Schema;
        }
    }
}
