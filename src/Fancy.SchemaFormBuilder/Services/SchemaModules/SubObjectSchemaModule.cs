using System.Collections.Generic;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Adds a subobject to the schema.
    /// </summary>
    public class SubObjectSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormSubObjectAttribute>() != null)
            {
                JObject currentSchemaObject = context.Element.GetOrCreateSchemaObject();

                // A schema type for a simple type could not be found, we assume the property references an complex type
                // Build the schema for a complext type
                JObject complexSchema = context.SchemaBuilder.BuildSchema(context.Property.PropertyType);

                currentSchemaObject["title"] = new JValue(context.Property.Name);

                // Add the properties of the complex schema to the current schema
                foreach (KeyValuePair<string, JToken> schemaItem in complexSchema)
                {
                    currentSchemaObject[schemaItem.Key] = schemaItem.Value;
                }
            }
        }
    }
}