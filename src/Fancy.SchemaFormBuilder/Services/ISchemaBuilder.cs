using System;

using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Interface for a JSON schema builder.
    /// </summary>
    public interface ISchemaBuilder
    {
        /// <summary>
        /// Builds the JSON schema for a specified type.
        /// </summary>
        /// <param name="type">The type to build the schema for.</param>
        /// <returns>The JSON schema.</returns>
        JObject BuildSchema(Type type, CultureInfo cultureInfo);
    }
}
