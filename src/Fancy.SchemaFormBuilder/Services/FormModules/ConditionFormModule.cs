using System;
using System.Linq;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds a condition to the current form element.
    /// </summary>
    public class ConditionFormModule : FormModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            // Get the attribute
            FormConditionAttribute conditionAttribute = context.Property.GetCustomAttribute<FormConditionAttribute>();

            // If the current property has a condition add it
            if (conditionAttribute != null)
            {
                string condition = FormModuleHelper.ConvertConditionToAbsolutePath(context.DtoType.Name, context.FullPropertyPath, conditionAttribute.Condition);

                context.GetOrCreateCurrentFormElement()["condition"] = new JValue(condition);
            }
        }
    }
}
