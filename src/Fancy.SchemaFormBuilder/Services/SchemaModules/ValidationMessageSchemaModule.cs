using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Adds a validation message to the schema if a property has the "ValidationMessage" attribute.
    /// </summary>
    public class ValidationMessageSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormValidationMessageAttribute>() != null)
            {
                FormValidationMessageAttribute validationMessage = context.Property.GetCustomAttribute<FormValidationMessageAttribute>();
                context.Element.GetOrCreateSchemaObject()["validationMessage"] = validationMessage.MessageText;
            }
        }
    }
}
