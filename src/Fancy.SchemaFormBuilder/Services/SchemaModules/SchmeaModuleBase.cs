using System.Globalization;
using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    public abstract class SchmeaModuleBase : ISchemaBuilderModule
    {
        /// <summary>
        /// The language provider.
        /// </summary>
        private readonly ILanguageProvider _languageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchmeaModuleBase"/> class.
        /// </summary>
        protected SchmeaModuleBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchmeaModuleBase"/> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        protected SchmeaModuleBase(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public abstract void Process(SchemaBuilderContext context);

        /// <summary>
        /// Gets the text for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns></returns>
        protected string GetTextForKey(string key, CultureInfo cultureInfo)
        {
            if (_languageProvider != null)
            {
                // If a language provider is availabe call it to get the text
                return _languageProvider.GetTextForKey(key, cultureInfo);
            }
            else
            {
                // If no language provider is available return the key as text
                return key;
            }
        }
    }
}