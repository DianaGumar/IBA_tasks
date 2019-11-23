using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_7915.Controllers;

namespace WebAPI_7915.Classes
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
            var str = context.Request.Query["str"];
            var connectStr = context.Request.Query["connectStr"];

            //status code 403- asses to resurs is denied
            if (String.IsNullOrEmpty(str)) { context.Response.StatusCode = 403; }
            else if (String.IsNullOrEmpty(connectStr)) { context.Response.StatusCode = 403; }
            else if (str == "1")
            {
                string sql = "SELECT* FROM books";
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(Viev(sql, connectStr));
            }
            else if (str == "2")
            {
                string sql = "SELECT * FROM books WHERE bookPages > 20";
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(Viev(sql, connectStr));
            }
            else 
            {
                context.Response.StatusCode = 403;      
            }
            await this.next(context);
        }

        private string Viev(string sql, string connectStr)
        {
            BookDBController bc = new BookDBController(sql, connectStr);
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
