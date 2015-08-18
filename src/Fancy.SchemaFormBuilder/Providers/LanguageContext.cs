using System;
using System.Globalization;

namespace Fancy.SchemaFormBuilder.Providers
{
    /// <summary>
    /// A conteext for a language provider with information usable to decide which strings to return to a text request.
    /// </summary>
    public class LanguageContext
    {
        /// <summary>
        /// Gets or sets the culture for the required texts.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Gets or sets the type of the dto the required texts shall apply to.
        /// </summary>
        /// <value>
        /// The type of the dto.
        /// </value>
        public Type DtoType { get; set; }
    }
}
