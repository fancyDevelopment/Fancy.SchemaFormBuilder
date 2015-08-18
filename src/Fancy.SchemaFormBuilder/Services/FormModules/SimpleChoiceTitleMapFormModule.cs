using System.Reflection;
using System.Text;

using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds a title map to the form if the current property is marked with the <see cref="FormSimpleChoiceAttribute"/>.
    /// </summary>
    public class SimpleChoiceTitleMapFormModule : FormModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleChoiceTitleMapFormModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public SimpleChoiceTitleMapFormModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            FormSimpleChoiceAttribute simpleChoiceAttribute = context.Property.GetCustomAttribute<FormSimpleChoiceAttribute>();

            if (simpleChoiceAttribute != null)
            {
                StringBuilder choices = new StringBuilder();

                JObject titleMap = new JObject();


                foreach (string value in simpleChoiceAttribute.Values)
                {
                    titleMap[value] = GetTextForKey(value, context);
                }

                context.GetOrCreateCurrentFormElement()["type"] = new JValue("select");
                context.GetOrCreateCurrentFormElement()["titleMap"] = JObject.Parse(choices.ToString());
            }
        }
    }
}
