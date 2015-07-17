using System;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Base implementation of the <see cref="ISchemaFormBuilder"/> interface.
    /// </summary>
    public abstract class SchemaFormBuilderBase : ISchemaFormBuilder
    {
        /// <summary>
        /// The form builder.
        /// </summary>
        private FormBuilder _formBuilder;

        /// <summary>
        /// The schema builder.
        /// </summary>
        private SchemaBuilder _schemaBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaFormBuilderBase"/> class.
        /// </summary>
        public SchemaFormBuilderBase()
        {
            this.Initialize();
        }

        /// <summary>
        /// Creates the schema form info object to the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The schema form info.
        /// </returns>
        public SchemaFormInfo CreateSchemaForm(Type type)
        {
            SchemaFormInfo result = new SchemaFormInfo();

            result.Schema = this._schemaBuilder.BuildSchema(type);
            result.Form = this._formBuilder.BuildForm(type);
            result.Type = type;

            return result;
        }

        /// <summary>
        /// Configures the form builder.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        protected abstract void ConfigureFormBuilder(FormBuilder formBuilder);

        /// <summary>
        /// Configures the schema builder.
        /// </summary>
        /// <param name="schemaBuilder">The schema builder.</param>
        protected abstract void ConfigureSchemaBuilder(SchemaBuilder schemaBuilder);

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            this._formBuilder = new FormBuilder();
            this._schemaBuilder = new SchemaBuilder();

            this.ConfigureFormBuilder(this._formBuilder);
            this.ConfigureSchemaBuilder(this._schemaBuilder);
        }
    }
}
