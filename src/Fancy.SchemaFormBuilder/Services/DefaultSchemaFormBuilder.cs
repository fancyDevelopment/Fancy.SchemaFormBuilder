using Fancy.SchemaFormBuilder.Providers;
using Fancy.SchemaFormBuilder.Services.FormModules;
using Fancy.SchemaFormBuilder.Services.SchemaModules;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Default implementation of an schema form builder which uses all supported modules.
    /// </summary>
    public class DefaultSchemaFormBuilder : SchemaFormBuilderBase
    {
        /// <summary>
        /// The url lookup provider.
        /// </summary>
        private readonly IUrlLookupProvider _urlLookupProvider;

        /// <summary>
        /// The language provider.
        /// </summary>
        private readonly ILanguageProvider _languageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSchemaFormBuilder"/> class.
        /// </summary>
        public DefaultSchemaFormBuilder()
        {
            _urlLookupProvider = null;
            _languageProvider = null;

            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSchemaFormBuilder"/> class.
        /// </summary>
        /// <param name="urlLookupProvider">The URL lookup provider.</param>
        public DefaultSchemaFormBuilder(IUrlLookupProvider urlLookupProvider, ILanguageProvider languageProvider)
        {
            _urlLookupProvider = urlLookupProvider;
            _languageProvider = languageProvider;

            Initialize();
        }

        /// <summary>
        /// Configures the form builder.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        protected override void ConfigureFormBuilder(FormBuilder formBuilder)
        {
            formBuilder.UseSectionModule(_languageProvider);
            formBuilder.UseTextFormModule(_languageProvider);
            formBuilder.UseHelpModule(_languageProvider);
            formBuilder.UseSubObjectModule();
            formBuilder.UseArrayModule(_languageProvider);
            formBuilder.UseTitleKeyModule();
            formBuilder.UseEnumTitleMapModule(_languageProvider);
            formBuilder.UseDisplayModule();
            formBuilder.UseSimpleChoiceModule(_languageProvider);
            formBuilder.UseBoolAsTitleMapModule(_languageProvider);
            formBuilder.UseConditionModule();
        }

        /// <summary>
        /// Configures the schema builder.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        protected override void ConfigureSchemaBuilder(SchemaBuilder schemaBuilder)
        {
            schemaBuilder.UseAttributedPropertiesOnlyModule();
            schemaBuilder.UseTypeModule();
            schemaBuilder.UseSubObjectModule();
            schemaBuilder.UseArrayModule();
            schemaBuilder.UseTitleModule(_languageProvider);
            schemaBuilder.UseRequiredModule();
            schemaBuilder.UseRegExValidationModule();
            schemaBuilder.UseMaxLengthModule();
            schemaBuilder.UseValidationMessageModule(_languageProvider);
            schemaBuilder.UseUrlLookupProviderModule(_urlLookupProvider);
        }
    }
}
