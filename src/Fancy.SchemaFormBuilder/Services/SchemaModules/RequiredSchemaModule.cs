using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Identifies weather a property is required and adds the information to the context.
    /// </summary>
    public class RequiredSchemaModule : SchmeaModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(SchemaBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormRequiredAttribute>() != null)
            {
                // The property is a required property
                context.Element.IsRequired = true;
            }
        }
    }
}
