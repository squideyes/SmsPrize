using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using SmsPrize.Web.Services;
using System.IO;

namespace SmsPrize.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var configPath = Path.Combine(appEnv.ApplicationBasePath, "..", "..");

            Configuration = new Configuration(configPath).AddJsonFile("config.json").
                AddEnvironmentVariables("SmsPrize_");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddInstance(Configuration);

            services.AddScoped<SmsService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
