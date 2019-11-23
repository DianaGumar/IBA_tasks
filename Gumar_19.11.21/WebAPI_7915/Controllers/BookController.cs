using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI_7915.Classes;

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
        public IEnumerable<string> Get()
        {
            //var rng = new Random();
            return new string[] { "hi", "hiii"};
        }

        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
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
