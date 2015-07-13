namespace Fancy.SchemaFormBuilder.Providers
{
    /// <summary>
    /// Interface to retrieve url to named lookup types.
    /// </summary>
    public interface IUrlLookupProvider
    {
        /// <summary>
        /// Gets the type of the URL to the REST endpoint for the specified lookup type.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        /// <returns>The URL to the REST endpoint.</returns>
        /// <remarks>
        /// The URL returned by this method has to deliver title map when called. 
        /// </remarks>
        string GetUrlForLookupType(string lookupType);
    }
}
