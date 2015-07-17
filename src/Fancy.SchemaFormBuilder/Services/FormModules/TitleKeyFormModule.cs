using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds the member of an property to the form if it has a title attribute.
    /// </summary>
    public class TitleKeyFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            if(context.Property.GetCustomAttribute<FormTitleAttribute>() != null)
            {
                context.GetOrCreateCurrentFormElement()["key"] = context.FullPropertyPath;
            }
        }
    }
}
