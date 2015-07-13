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
        /// Initializes a new instance of the <see cref="DefaultSchemaFormBuilder"/> class.
        /// </summary>
        public DefaultSchemaFormBuilder()
        {
            _urlLookupProvider = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSchemaFormBuilder"/> class.
        /// </summary>
        /// <param name="urlLookupProvider">The URL lookup provider.</param>
        public DefaultSchemaFormBuilder(IUrlLookupProvider urlLookupProvider)
        {
            _urlLookupProvider = urlLookupProvider;
        }

        /// <summary>
        /// Configures the form builder.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        protected override void ConfigureFormBuilder(FormBuilder formBuilder)
        {
            formBuilder.UseSectionModule();
            formBuilder.UseHelpModule();
            formBuilder.UseSubObjectModule();
            formBuilder.UseArrayModule();
            formBuilder.UseTextFormModule();
            formBuilder.UseTitleKeyModule();
            formBuilder.UseEnumTitleMapModule();
            formBuilder.UseDisplayModule();
            formBuilder.UseSimpleChoiceModule();
            formBuilder.UseBoolAsTitleMapModule();
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
            schemaBuilder.UseTitleModule();
            schemaBuilder.UseRequiredModule();
            schemaBuilder.UseRegExValidationModule();
            schemaBuilder.UseMaxLengthModule();
            schemaBuilder.UseValidationMessageModule();
            schemaBuilder.UseUrlLookupProviderModule(_urlLookupProvider);
        }
    }
}
