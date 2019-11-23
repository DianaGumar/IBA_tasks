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

        [HttpGet]
        public List<Book> Get()
        {
            BookDBController bc = new BookDBController("IBA", "root", "1111");

            return bc.reed();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            BookDBController bc = new BookDBController("IBA", "root", "1111");

            return bc.reed(id);
        }

        //[HttpPost]
        //public IActionResult Post([FromQuery]Book book)
        //{
        //    if (book == null) { return BadRequest(); }

        //    BookDBController bc = new BookDBController("IBA", "root", "1111");

        //    if (bc.create(book)) { return Ok(book); }
        //    else return BadRequest();
        //}


        //https://localhost:44328/Book/IBA,root,1111,SELECT*FROM%20books%20where%20bookID=4
        [HttpGet("{DBName},{login},{password},{sql}")]
        public List<Book> Post(string DBName, string login, string password, string sql)
        {
            BookDBController bc = new BookDBController(sql, DBName, login , password);

            return bc.getWhere();
        }
    }
}
