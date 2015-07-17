using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Identifies weather a property has a regular expression and adds the patter to the schema element.
    /// </summary>
    public class RegExValidationSchemaModule : SchmeaModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormRegExValidationAttribute>() != null)
            {
                FormRegExValidationAttribute regExValidation = context.Property.GetCustomAttribute<FormRegExValidationAttribute>();

                JObject schemaObject = context.Element.GetOrCreateSchemaObject();

                // Set the regex and the validation message to the current element
                schemaObject["pattern"] = new JValue(regExValidation.RegEx);
            }
        }
    }
}
