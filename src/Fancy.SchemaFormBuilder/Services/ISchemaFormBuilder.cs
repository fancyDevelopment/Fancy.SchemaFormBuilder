using System;
using System.Globalization;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Interface for the main service to create a schema and a form description from a .NET type.
    /// </summary>
    public interface ISchemaFormBuilder
    {
        /// <summary>
        /// Creates the schema form info object to the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The schema form info.</returns>
        SchemaFormInfo CreateSchemaForm(Type type);

        /// <summary>
        /// Creates the schema form info object to the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The schema form info.</returns>
        SchemaFormInfo CreateSchemaForm(Type type, CultureInfo cultureInfo);
    }
}
