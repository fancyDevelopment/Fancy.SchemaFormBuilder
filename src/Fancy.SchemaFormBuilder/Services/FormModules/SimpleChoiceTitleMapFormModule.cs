using System.Reflection;
using System.Text;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds a title map to the form if the current property is marked with the <see cref="FormSimpleChoiceAttribute"/>.
    /// </summary>
    public class SimpleChoiceTitleMapFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            FormSimpleChoiceAttribute simpleChoiceAttribute = context.Property.GetCustomAttribute<FormSimpleChoiceAttribute>();

            if (simpleChoiceAttribute != null)
            {
                StringBuilder choices = new StringBuilder();

                JObject titleMap = new JObject();


                foreach (string value in simpleChoiceAttribute.Values)
                {
                    titleMap[value] = value;
                }

                context.GetOrCreateCurrentFormElement()["type"] = new JValue("select");
                context.GetOrCreateCurrentFormElement()["titleMap"] = JObject.Parse(choices.ToString());
            }
        }
    }
}
