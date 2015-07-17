using System.Linq;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Checks weather the current property has a <see cref="FormAttribute"/>. If not the module stops the pipeline.
    /// </summary>
    public class AttributedPropertiesOnlySchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            if (!context.Property.GetCustomAttributes().Any(a => a.GetType().GetTypeInfo().IsSubclassOf(typeof(FormAttribute))))
            {
                context.FinishProcessing = true;
            }
        }
    }
}
