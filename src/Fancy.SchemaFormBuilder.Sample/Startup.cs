using AutoMapper;

using Fancy.SchemaFormBuilder.Sample.ViewModels;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fancy.SchemaFormBuilder.Sample
{
    /// <summary>
    /// Startup class to initialize the runtime.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            // Create mapping profiles required to transfer data between different types with similar properties.
            Mapper.CreateMap<EditEmployeeVm, FullEmployeeVm>();
            Mapper.CreateMap<FullEmployeeVm, EditEmployeeVm>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services collection to be filled within this method.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the shema for builder project
            services.AddDefaultSchemaFormBuilder();
            
            // Add mvc services
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
