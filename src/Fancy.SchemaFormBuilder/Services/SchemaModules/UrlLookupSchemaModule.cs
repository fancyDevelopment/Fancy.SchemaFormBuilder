using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;
using Fancy.SchemaFormBuilder.Providers;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Makes a property of a form a look up property which retrieves its data from an other REST endpoint.
    /// </summary>
    public class UrlLookupSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// The url lookup provider.
        /// </summary>
        private readonly IUrlLookupProvider _urlLookupProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlLookupSchemaModule"/> class.
        /// </summary>
        /// <param name="urlLookupProvider">The URL lookup provider.</param>
        public UrlLookupSchemaModule(IUrlLookupProvider urlLookupProvider)
        {
            _urlLookupProvider = urlLookupProvider;
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            FormUrlLookupAttribute urlLookupAttribute = context.Property.GetCustomAttribute<FormUrlLookupAttribute>();

            if (urlLookupAttribute != null && _urlLookupProvider != null)
            {
                string url = _urlLookupProvider.GetUrlForLookupType(urlLookupAttribute.LookupType);

                // Set up the link object
                JObject link = new JObject();
                link["rel"] = new JValue("options");
                link["href"] = new JValue(url);

                // Add link object as array to the schema
                context.Element.GetOrCreateSchemaObject()["links"] = new JArray(link);
            }
        }
    }
}
