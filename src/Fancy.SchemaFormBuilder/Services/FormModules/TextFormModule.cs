using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Adds text information to the form if the current property has the form text attribute.
    /// </summary>
    public class TextFormModule : IFormBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            // Get all help attributes
            List<FormTextAttribute> texts = context.Property.GetCustomAttributes<FormTextAttribute>().ToList();

            // If the current property has no helps this module has nothing to to
            if (!texts.Any())
            {
                return;
            }

            foreach (FormTextAttribute text in texts)
            {
                // Create the help JSON object
                JObject textObject = new JObject();
                textObject["type"] = new JValue("help");
                textObject["helpvalue"] = new JValue("<p>" + text.Text + "</p>");

                context.CurrentFormElementParent.Add(textObject);
            }
        }
    }
}
