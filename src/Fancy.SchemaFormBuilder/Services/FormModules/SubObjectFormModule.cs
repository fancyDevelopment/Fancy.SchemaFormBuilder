using System;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds properties of sub objects to the form if the current property is a form sub object.
    /// </summary>
    public class SubObjectFormModule : FormModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            // Test to the form subobject attribute
            if (context.Property.GetCustomAttribute<FormSubObjectAttribute>() != null)
            {
                // Get the type from the property directly
                Type subType = context.Property.PropertyType;

                // Create the subform
                JContainer properties = context.FormBuilder.BuildForm(subType, context.OriginDtoType, context.TargetCulture, context.FullPropertyPath);

                // Merge the properties of the sub object into the current context
                context.CurrentFormElementParent.Merge(properties);
            }
        }
    }
}
