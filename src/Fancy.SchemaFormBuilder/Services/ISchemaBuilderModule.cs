namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Interface for a schema builder pipeline module. The module has to process a context and add information to it 
    /// as far as it is possible and control the further execution of the pipeline.
    /// </summary>
    public interface ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        void Process(SchemaBuilderContext context);
    }
}
