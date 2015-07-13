using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds properties of sub objects to the form if the current property is a form sub object.
    /// </summary>
    public class ArrayFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            FormArrayAttribute arrayAttribute = context.Property.GetCustomAttribute<FormArrayAttribute>();
                
            // Test to the form subobject attribute
            if (arrayAttribute != null)
            {
                if (context.Property.PropertyType.GetInterfaces()
                    .Where(i => i.GetTypeInfo().IsGenericType)
                    .Select(i => i.GetGenericTypeDefinition()).Any(i => i == typeof (IEnumerable<>)))
                {
                    // Get the subtype from a generic type argument
                    Type subType = context.Property.PropertyType.GetGenericArguments()[0];

                    // Create the subform
                    JContainer properties = context.FormBuilder.BuildForm(subType, context.FullPropertyPath + "[]");

                    // Merge the properties of the sub object into the current context
                    JObject currentFormElement = context.GetOrCreateCurrentFormElement();
                    currentFormElement["key"] = context.FullPropertyPath;
                    currentFormElement["items"] = properties;

                    if (!string.IsNullOrEmpty(arrayAttribute.AddButtonTitle))
                    {
                        currentFormElement["add"] = new JValue(arrayAttribute.AddButtonTitle);
                    }
                }
                else
                {
                    throw new InvalidOperationException("An " + nameof(FormArrayAttribute) + " must always be on a property with a type derived from IEnumerable<>");
                }
            }
        }
    }
}
