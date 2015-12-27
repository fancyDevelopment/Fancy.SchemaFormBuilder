using Fancy.SchemaFormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fancy.SchemaFormBuilder
{
    /// <summary>
    /// Extension methods for the "IServiceCollection" interface.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Convenience method to register the default schema form builder to IOC container.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddDefaultSchemaFormBuilder(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISchemaFormBuilder, DefaultSchemaFormBuilder>();
            return serviceCollection;
        }
    }
}