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
    public class ConditionFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            // Get the attribute
            FormConditionAttribute conditionAttribute = context.Property.GetCustomAttribute<FormConditionAttribute>();

            // If the current property has a condition add it
            if (conditionAttribute != null)
            {
                string condition = ConvertConditionToAbsolutePath(context.ObjectType.Name, context.FullPropertyPath, conditionAttribute.Condition);

                context.GetOrCreateCurrentFormElement()["condition"] = new JValue(condition);
            }
        }

        /// <summary>
        /// Converts the condition expression to absolute path.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="fullPropertyPath">The full property path.</param>
        /// <param name="conditionExpression">The condition expression.</param>
        /// <returns>
        /// The converted expression.
        /// </returns>
        private string ConvertConditionToAbsolutePath(string typeName, string fullPropertyPath, string conditionExpression)
        {
            string fullPathToObject = "model";

            // Check the property path is valid
            if (!conditionExpression.Contains('.'))
            {
                throw new InvalidOperationException("The condition must start with the type name and must navigate to a property.");
            }

            // Set up the path to the object
            if (fullPropertyPath.Contains('.'))
            {
                // Clip the last path item because we want only the path to the object and not to the property itself
                fullPathToObject = fullPathToObject + "." + fullPropertyPath.Substring(0, fullPropertyPath.LastIndexOf('.'));
            }

            return conditionExpression.Replace(typeName, fullPathToObject);
        }
    }
}
