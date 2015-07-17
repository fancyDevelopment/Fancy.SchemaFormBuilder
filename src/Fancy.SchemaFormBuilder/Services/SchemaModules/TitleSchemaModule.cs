using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Identifies weather a property is required and adds the information to the context.
    /// </summary>
    public class TitleSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormTitleAttribute>() != null)
            {
                string title = context.Property.GetCustomAttribute<FormTitleAttribute>().Title;

                JObject schemaObject = context.Element.GetOrCreateSchemaObject();

                // Set the title to the current element
                schemaObject["title"] = title;
            }
        }
    }
}
