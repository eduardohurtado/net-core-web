using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using net_core_web.Model;
using Microsoft.EntityFrameworkCore;

namespace net_core_web
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContextPool<AppDbContext>(options =>
            //     options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")
            //     )
            // );
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // Instance store just one time on.
            services.AddSingleton<IFriendStore, MockFriendRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging() || env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
            }

            // DefaultFilesOptions d = new DefaultFilesOptions();
            // d.DefaultFileNames.Clear();
            // d.DefaultFileNames.Add("index.html");
            // app.UseDefaultFiles(d);

            app.UseStaticFiles();

            // Default routing
            // app.UseMvcWithDefaultRoute();

            // Custom routing MVC
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            // });

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Environment: " + env.EnvironmentName);
            // });

            // app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //     });
            // });

            app.UseMvc();
        }
    }
}
