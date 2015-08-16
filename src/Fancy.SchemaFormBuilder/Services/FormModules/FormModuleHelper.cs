using System;
using System.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    public static class FormModuleHelper
    {
        /// <summary>
        /// Converts a condition expression to an absolute path.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="fullPropertyPath">The full property path.</param>
        /// <param name="conditionExpression">The condition expression.</param>
        /// <returns>
        /// The converted expression.
        /// </returns>
        public static string ConvertConditionToAbsolutePath(string typeName, string fullPropertyPath, string conditionExpression)
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
