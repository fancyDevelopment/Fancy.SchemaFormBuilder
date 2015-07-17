using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Configures an element how to display it.
    /// </summary>
    public class DisplayFormModule : FormModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(FormBuilderContext context)
        {
            if (context.Property.GetCustomAttribute<FormDisplayAttribute>() != null)
            {
                FormDisplayAttribute formDisplayAttribute = context.Property.GetCustomAttribute<FormDisplayAttribute>();

                // Build a new hierarchy object for the element
                JObject hierachyObject = new JObject();
                JArray hierarcyItems = new JArray();

                hierachyObject["type"] = new JValue("section");
                hierachyObject["items"] = hierarcyItems;
                
                if (context.CurrentFormElement != null)
                {
                    // Move the current element into the form hierarcy
                    hierarcyItems.Add(context.CurrentFormElement);
                    context.CurrentFormElementParent.Remove(context.CurrentFormElement);
                    context.CurrentFormElementParent.Add(hierachyObject);
                }

                // Set the new parent element to the current hierarchy
                context.CurrentFormElementParent = hierarcyItems;

                string cssClasses = ConvertDisplayWidthToCssClass(formDisplayAttribute.DisplayWidth);

                if (!string.IsNullOrEmpty(cssClasses))
                {
                    hierachyObject["htmlClass"] = new JValue(cssClasses);
                }
            }
        }

        /// <summary>
        /// Converts the display width to CSS classes.
        /// </summary>
        /// <param name="displayWidth">The display width.</param>
        /// <returns>Names of CSS classes.</returns>
        private string ConvertDisplayWidthToCssClass(DisplayWidth displayWidth)
        {
            switch (displayWidth)
            {
                case DisplayWidth.Full:
                    return "col-md-12";

                case DisplayWidth.Half:
                    return "col-sm-12 col-md-6";

                case DisplayWidth.Quarter:
                    return "col-sm-6 col-md-3";
            }

            return "";
        }
    }
}
