using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_7915.Classes
{
    public class DBMiddleWare
    {
        RequestDelegate next;

        public DBMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        //организован обычный вывод на страницу.
        public async Task InvokeAsync(HttpContext context)
        {
            var str = context.Request.Query["str"];

            if (str == "1")
            {
                string sql = "SELECT* FROM books";
                await context.Response.WriteAsync(Viev(sql));
                //await context.Response.WriteAsync("hi");
            }
            if (str == "2")
            {
                string sql = "SELECT * FROM books WHERE bookPages > 20";
                await context.Response.WriteAsync(Viev(sql));
            }
            else 
            {
                context.Response.StatusCode = 403;
                await this.next(context); 
            }
        }

        private string Viev(string sql)
        {
            BookController bc = new BookController(sql);
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
