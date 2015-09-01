using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds properties of sub objects to the form if the current property is a form sub object.
    /// </summary>
    public class ArrayFormModule : FormModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayFormModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public ArrayFormModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
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
                    JContainer properties = context.FormBuilder.BuildForm(subType, context.OriginDtoType, context.TargetCulture, context.FullPropertyPath + "[]");

                    // Merge the properties of the sub object into the current context
                    JObject currentFormElement = context.GetOrCreateCurrentFormElement();
                    currentFormElement["key"] = context.FullPropertyPath;
                    currentFormElement["items"] = properties;

                    if (!string.IsNullOrEmpty(arrayAttribute.AddButtonTitle))
                    {
                        string addText = GetTextForKey(arrayAttribute.AddButtonTitle, context);
                        currentFormElement["add"] = new JValue(addText);
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
