using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using HolyAngels.Services;

namespace HolyAngels
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            DataService.RegisterClassMaps();
            services.AddSingleton(typeof(DataService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    "default_ministry",
                    template: "Ministries/{*ministry}",
                    defaults: new {controller="Home", action="Ministries"}
                );
                routes.MapRoute(
                    "default_events",
                    template: "EventCalendar/{*events}",
                    defaults: new {controller="Home", action="Events"}
                );
                routes.MapRoute(
                    "default_articles",
                    template: "Articles/{*article}",
                    defaults: new {controller="Home", action="Articles"}
                );
            });
        }
    }
}
