using System;

using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Interface for a form builder.
    /// </summary>
    public interface IFormBuilder
    {
        /// <summary>
        /// Builds the form.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A description of the form in JSON.</returns>
        JContainer BuildForm(Type type, CultureInfo cultureInfo);

        /// <summary>
        /// Builds a sub form starting from a specified property path.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="originType">Type of the origin object for which the processing was started.</param
        /// <param name="sourcePropertyPath">The source property path to use as start.</param>
        /// <returns>
        /// A description of the form in JSON
        /// </returns>
        JContainer BuildForm(Type type, Type originType, CultureInfo cultureInfo, string sourcePropertyPath);
    }
}
