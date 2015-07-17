using System.Reflection;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Context with all information required in the schema builder pipeline.
    /// </summary>
    public class SchemaBuilderContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaBuilderContext"/> class.
        /// </summary>
        public SchemaBuilderContext()
        {
            this.Element = new SchemaElement();
        }

        /// <summary>
        /// Gets the schema builder.
        /// </summary>
        /// <value>
        /// The schema builder.
        /// </value>
        public ISchemaBuilder SchemaBuilder { get; internal set; }

        /// <summary>
        /// Gets the property which is currently processed by the pipeline.
        /// </summary>
        /// <value>
        /// The property.
        /// </value>
        public PropertyInfo Property { get; internal set; }

        /// <summary>
        /// Gets the element which will be written to the JSON schema.
        /// </summary>
        /// <remarks>
        /// This property contains the result of processing a property by the pipeline. All modules can write into this property
        /// to extends the schema information of the property being processed.
        /// </remarks>
        /// <value>
        /// The element.
        /// </value>
        public SchemaElement Element { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pipeline shall finish processing after the module has benn run or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the shall finish the processing; otherwise, <c>false</c>.
        /// </value>
        public bool FinishProcessing { get; set; }
    }
}
