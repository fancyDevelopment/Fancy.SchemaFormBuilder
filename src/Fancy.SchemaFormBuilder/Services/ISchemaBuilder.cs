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
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>
        /// The JSON schema.
        /// </returns>
        JObject BuildSchema(Type type, CultureInfo cultureInfo);

        /// <summary>
        /// Builds the JSON schema for a specified type.
        /// </summary>
        /// <param name="type">The type to build the schema for.</param>
        /// <param name="originType">Type of the origin object for which the processing was started.</param
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>
        /// The JSON schema.
        /// </returns>
        JObject BuildSchema(Type type, Type originType, CultureInfo cultureInfo);
    }
}
