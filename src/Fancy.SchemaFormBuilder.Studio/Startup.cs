using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fancy.SchemaFormBuilder.Studio
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }

        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
