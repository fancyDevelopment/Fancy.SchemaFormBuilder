using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;
using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Identifies weather a property is required and adds the information to the context.
    /// </summary>
    public class TitleSchemaModule : SchmeaModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleSchemaModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public TitleSchemaModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormTitleAttribute>() != null)
            {
                string title = context.Property.GetCustomAttribute<FormTitleAttribute>().Title;

                JObject schemaObject = context.Element.GetOrCreateSchemaObject();

                // Set the title to the current element
                schemaObject["title"] = GetTextForKey(title, context);
            }
        }
    }
}
