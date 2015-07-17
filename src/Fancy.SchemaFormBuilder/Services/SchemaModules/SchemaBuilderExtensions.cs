using Fancy.SchemaFormBuilder.Providers;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Extension methods to conveniently configure the schema builder pipeline.
    /// </summary>
    public static class SchemaBuilderExtensions
    {
        /// <summary>
        /// Adds the attibuted properties only module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseAttributedPropertiesOnlyModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new AttributedPropertiesOnlySchemaModule());
        }

        /// <summary>
        /// Adds the type module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseTypeModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new TypeSchemaModule());
        }

        /// <summary>
        /// Adds the sub object module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseSubObjectModule(this SchemaBuilder schemaBuilder)
        {
           schemaBuilder.AddPipelineModule(new SubObjectSchemaModule());
        }

        /// <summary>
        /// Adds the array module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseArrayModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new ArraySchemaModule());
        }

        /// <summary>
        /// Adds the required module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseRequiredModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new RequiredSchemaModule());
        }

        /// <summary>
        /// Adds the title module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseTitleModule(this SchemaBuilder schemaBuilder, ILanguageProvider languaageProvider)
        {
            schemaBuilder.AddPipelineModule(new TitleSchemaModule(languaageProvider));
        }

        /// <summary>
        /// Adds the regular expression validation module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseRegExValidationModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new RegExValidationSchemaModule());
        }

        /// <summary>
        /// Adds the validation message module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseValidationMessageModule(this SchemaBuilder schemaBuilder, ILanguageProvider languaageProvider)
        {
            schemaBuilder.AddPipelineModule(new ValidationMessageSchemaModule(languaageProvider));
        }

        /// <summary>
        /// Adds the maximum length module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        public static void UseMaxLengthModule(this SchemaBuilder schemaBuilder)
        {
            schemaBuilder.AddPipelineModule(new MaxLengthSchemaModule());
        }

        /// <summary>
        /// Adds the URL lookup provider module to the pipeline.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        /// <param name="urlLookupProvider">The URL lookup provider.</param>
        public static void UseUrlLookupProviderModule(this SchemaBuilder schemaBuilder, IUrlLookupProvider urlLookupProvider)
        {
            schemaBuilder.AddPipelineModule(new UrlLookupSchemaModule(urlLookupProvider));
        }
    }
}
