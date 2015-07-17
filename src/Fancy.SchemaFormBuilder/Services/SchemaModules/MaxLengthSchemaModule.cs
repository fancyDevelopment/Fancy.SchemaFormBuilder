using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Sets the max length to a property if the attribute is declared.
    /// </summary>
    public class MaxLengthSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormMaxLengthAttribute>() != null)
            {
                FormMaxLengthAttribute maxLength = context.Property.GetCustomAttribute<FormMaxLengthAttribute>();

                JObject schemaObject = context.Element.GetOrCreateSchemaObject();

                // Set the regex and the validation message to the current element
                schemaObject["maxLength"] = new JValue(maxLength.Length);
            }
        }
    }
}
