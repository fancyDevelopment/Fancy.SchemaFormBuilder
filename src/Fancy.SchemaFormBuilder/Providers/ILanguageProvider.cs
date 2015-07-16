using System.Globalization;

namespace Fancy.SchemaFormBuilder.Providers
{
    /// <summary>
    /// Provides languages resources for form and schema modules to render form in a specific language. 
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// Gets the text for a specific key in a specific language.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The text.</returns>
        string GetTextForKey(string key, CultureInfo culture);
    }
}