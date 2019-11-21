using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI_7915
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Map("/about", about );

            //указывает на класс middle ware
            app.UseMiddleware<Classes.DBMiddleWare>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await post(context);
                });
            });

        }

        //private void about(IApplicationBuilder app)
        //{
        //    app.Run(async (context) => await context.Response.WriteAsync("about"));
        //}

        //отслеживает пользовательский ввод в строку поиска и выводит тоже на страницу
        private async Task post(HttpContext context)
        {
            //string detiles = context.Request.QueryString.Value;

            string sql_all = "str=1  SELECT * FROM books";
            string sql_where = "str=2  SELECT * FROM books WHERE bookPages > 20";

            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"{sql_all}<br>{sql_where}<br>");
        }
        
    }
}
