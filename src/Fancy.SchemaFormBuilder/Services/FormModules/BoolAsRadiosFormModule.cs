using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Configures radio buttons into the form for booleans.
    /// </summary>
    public class BoolAsRadiosFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            if ((context.Property.PropertyType == typeof(bool) || context.Property.PropertyType == typeof(bool?)) && context.Property.GetCustomAttribute<FormBoolAsRadioAttribute>() != null)
            {
                FormBoolAsRadioAttribute boolAsRadioAttribute = context.Property.GetCustomAttribute<FormBoolAsRadioAttribute>();

                JArray titleMap = new JArray();

                // Add yes title
                JObject yesMap = new JObject();
                yesMap["value"] = new JValue(true);
                yesMap["name"] = new JValue(boolAsRadioAttribute.YesTitle);
                titleMap.Add(yesMap);

                JObject noMap = new JObject();
                noMap["value"] = new JValue(false);
                noMap["name"] = new JValue(boolAsRadioAttribute.NoTitle);
                titleMap.Add(noMap);

                context.GetOrCreateCurrentFormElement()["type"] = new JValue("radios");
                context.GetOrCreateCurrentFormElement()["titleMap"] = titleMap;
            }
        }
    }
}