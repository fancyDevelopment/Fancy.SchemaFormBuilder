using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds text information to the form if the current property has the form text attribute.
    /// </summary>
    public class TextFormModule : FormModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFormModule" /> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        public TextFormModule(ILanguageProvider languageProvider) : base(languageProvider)
        {
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            // Get all help attributes
            List<FormTextAttribute> texts = context.Property.GetCustomAttributes<FormTextAttribute>().ToList();

            // If the current property has no helps this module has nothing to to
            if (!texts.Any())
            {
                return;
            }

            foreach (FormTextAttribute textAttribute in texts)
            {
                string text = GetTextForKey(textAttribute.Text, context);

                // Create the help JSON object
                JObject textObject = new JObject();
                textObject["type"] = new JValue("help");
                textObject["helpvalue"] = new JValue("<p>" + text + "</p>");

                context.CurrentFormElementParent.Add(textObject);
            }
        }
    }
}
