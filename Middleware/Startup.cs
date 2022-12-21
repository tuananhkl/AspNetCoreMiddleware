using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Middleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ConsoleLoggerMiddleware>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configuqre(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/favicon.ico", (app) => {});
            
            app.Map("/map", MapHandler);
            app.UseMiddleware<ConsoleLoggerMiddleware>();

            app.Run(async context =>
            {
                Console.WriteLine("Hello World");
                await context.Response.WriteAsync("Hello World");
            });
        }

        private void MapHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("Hello for Map Method");
                await context.Response.WriteAsync("Hello for Map Method");
            });
        }
    }
}