using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI_7915.Controllers;
using WebAPI_7915.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        //private readonly ILogger<BookAPIController> _logger;

        //public BookAPIController(ILogger<BookAPIController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public string Get()
        {
            BookDBController bc = new BookDBController("IBA", "root", "1111");

            List<Book> books = bc.reed();
            StringBuilder sb = new StringBuilder();
            foreach (Book book in books)
            {
                sb.Append(book.ToString() + "\n");
            }

            return sb.ToString();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            BookDBController bc = new BookDBController("IBA", "root" ,"1111");

            return bc.reed(id).ToString();
        }

        //// POST api/users
        //[HttpPost]
        //public IActionResult Post([FromBody]User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return Ok(user);
        //}
    }
}
