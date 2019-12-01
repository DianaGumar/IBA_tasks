using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI_7915.Models.DataBase;
using System.Linq;
using Export;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        //[HttpGet]
        //public List<Book> Get()
        //{
        //    BookDBController bc = new BookDBController("IBA", "root", "1111");

        //    return bc.reed();
        //}

        //[HttpGet("{id}")]
        //public Book Get(int id)
        //{
        //    BookDBController bc = new BookDBController("IBA", "root", "1111");

        //    return bc.reed(id);
        //}

        //Book/IBA,root,1111,SELECT*FROM%20books%20where%20bookID=4
        //Book/Post? DBName = IBA & login = root & password = 1111 & sql = SELECT * FROM % 20books%20where%20bookID=4

        [HttpGet("{DBName},{login},{password},{sql}")]
        //[HttpPost] // with post isn't work
        public IActionResult Post(string DBName, string login, string password, string sql)
        {
            DAOLayer bc = new DAOLayer(sql.Replace("%", " "), DBName, login, password);

            List<List<string>> data = bc.reed();
            byte[] fileContents = ExcelExport.Export(data);

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: ExcelExport.ContentType,
                fileDownloadName: ExcelExport.FileDownloadName
                );


        }

    }
}
