using System;
using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds a title map to the form if the current property is an enumeration and the enumeration fields have a title.
    /// </summary>
    public class EnumTitleMapFormModule : FormModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTitleMapFormModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public EnumTitleMapFormModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            Type propertyType = context.Property.PropertyType;

            // Support enums and nullable enums
            if (propertyType.GetTypeInfo().IsEnum
                || (propertyType.GetTypeInfo().IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && Nullable.GetUnderlyingType(propertyType).GetTypeInfo().IsEnum))
            {
                FieldInfo[] enumMembers;

                // Read the enum members
                if (propertyType.GetTypeInfo().IsEnum)
                {
                    enumMembers = propertyType.GetFields(BindingFlags.Public | BindingFlags.Static);
                }
                else
                {
                    enumMembers = Nullable.GetUnderlyingType(propertyType).GetFields(BindingFlags.Public | BindingFlags.Static);
                }

                JArray titleMap = new JArray();

                // Create the title map objects
                foreach (FieldInfo enumMember in enumMembers)
                {
                    JObject title = new JObject();

                    title["value"] = new JValue(Convert.ChangeType(enumMember.GetValue(null), typeof(int)));

                    if (enumMember.GetCustomAttribute<FormTitleAttribute>() != null)
                    {
                        string titleKey = enumMember.GetCustomAttribute<FormTitleAttribute>().Title;
                        title["name"] = GetTextForKey(titleKey, context);
                        titleMap.Add(title);
                    }
                }

                // Add the title map to the element
                context.GetOrCreateCurrentFormElement()["titleMap"] = titleMap;
                context.GetOrCreateCurrentFormElement()["type"] = new JValue("radios");
            }
        }
    }
}
