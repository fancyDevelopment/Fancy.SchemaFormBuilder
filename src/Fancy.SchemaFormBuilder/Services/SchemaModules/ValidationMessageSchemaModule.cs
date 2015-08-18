using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Adds a validation message to the schema if a property has the "ValidationMessage" attribute.
    /// </summary>
    public class ValidationMessageSchemaModule : SchmeaModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleSchemaModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public ValidationMessageSchemaModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormValidationMessageAttribute>() != null)
            {
                FormValidationMessageAttribute validationMessage = context.Property.GetCustomAttribute<FormValidationMessageAttribute>();
                context.Element.GetOrCreateSchemaObject()["validationMessage"] = GetTextForKey(validationMessage.MessageText, context);
            }
        }
    }
}
