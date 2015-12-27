using Microsoft.AspNet.Builder;
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
            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
        }
    }
}
