using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Configures radio buttons into the form for booleans.
    /// </summary>
    public class BoolAsRadiosFormModule : FormModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolAsRadiosFormModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public BoolAsRadiosFormModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            if ((context.Property.PropertyType == typeof(bool) || context.Property.PropertyType == typeof(bool?)) && context.Property.GetCustomAttribute<FormBoolAsRadioAttribute>() != null)
            {
                FormBoolAsRadioAttribute boolAsRadioAttribute = context.Property.GetCustomAttribute<FormBoolAsRadioAttribute>();

                JArray titleMap = new JArray();

                // Add yes title
                JObject yesMap = new JObject();
                yesMap["value"] = new JValue(true);
                yesMap["name"] = new JValue(GetTextForKey(boolAsRadioAttribute.YesTitle, context));
                titleMap.Add(yesMap);

                JObject noMap = new JObject();
                noMap["value"] = new JValue(false);
                noMap["name"] = new JValue(GetTextForKey(boolAsRadioAttribute.NoTitle, context));
                titleMap.Add(noMap);

                context.GetOrCreateCurrentFormElement()["type"] = new JValue("radios");
                context.GetOrCreateCurrentFormElement()["titleMap"] = titleMap;
            }
        }
    }
}