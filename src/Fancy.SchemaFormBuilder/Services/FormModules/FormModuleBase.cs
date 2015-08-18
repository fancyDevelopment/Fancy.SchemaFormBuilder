using System.Globalization;
using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Base class for form modules.
    /// </summary>
    public abstract class FormModuleBase : IFormBuilderModule
    {
        /// <summary>
        /// The language provider.
        /// </summary>
        private readonly ILanguageProvider _languageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormModuleBase"/> class.
        /// </summary>
        protected FormModuleBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormModuleBase"/> class.
        /// </summary>
        /// <param name="languageProvider">The language provider.</param>
        protected FormModuleBase(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public abstract void Process(FormBuilderContext context);

        /// <summary>
        /// Gets the text for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="formBuilderContext">The form builder context.</param>
        /// <returns>
        /// The string for the requested key.
        /// </returns>
        protected string GetTextForKey(string key, FormBuilderContext formBuilderContext)
        {
            if (_languageProvider != null)
            {
                // If a language provider is availabe call it to get the text
                return _languageProvider.GetTextForKey(key, formBuilderContext.GetLanguageContext());
            }
            else
            {
                // If no language provider is available return the key as text
                return key;
            }
        }
    }
}