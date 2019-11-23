using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_7915.Controllers;

namespace WebAPI_7915.Models.MiddleWare
{
    public class DBMiddleWare
    {
        RequestDelegate next;

        public DBMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sql = context.Request.Query["sql"];
            var DBName = context.Request.Query["DBName"];
            var login = context.Request.Query["login"];
            var password = context.Request.Query["password"];

            //status code 403- asses to resurs is denied
            if (String.IsNullOrEmpty(sql) || 
                String.IsNullOrEmpty(DBName) ||
                String.IsNullOrEmpty(login) ||
                String.IsNullOrEmpty(password)) 
            { 
                context.Response.StatusCode = 403; 
            }
            else 
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(Viev(sql, DBName, login, password));
            }
            await this.next(context);
        }

        private string Viev(string sql, string DBName, string login, string password)
        {
            BookDBController bc = new BookDBController(sql, DBName, login, password);
            List<Book> books = new List<Book>();
            books = bc.reed(books);

            StringBuilder sb = new StringBuilder();
            foreach (Book book in books)
            {
                sb.Append(book.ToString() + "<br>");
            }

            return sb.ToString();
        }

    }
}
