using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI_7915
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseMiddleware<Classes.DBMiddleWare>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapGet("/", async context =>
                //{
                //    await Tip(context);
                //});
            });

        }


        //tip for sql 
        private async Task Tip(HttpContext context)
        {
            //string detiles = context.Request.QueryString.Value;

            string sql_all = "str=1    SELECT * FROM books";
            string sql_where = "str=2  SELECT * FROM books WHERE bookPages > 20";

            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"{sql_all}<br>{sql_where}<br>");
        }
        
    }
}
