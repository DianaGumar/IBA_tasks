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
    public class Controller : ControllerBase
    {

        //medicine_full,root,1111,SELECT* FROM%20applyings
        // IBA, root,1111,SELECT* FROM%20books
        //   IBA, root,1111,SELECT%20bookID%20FROM%20books
        //    Post? DBName = IBA & login = root & password = 1111 & sql = SELECT* FROM % 20books%20where%20bookID=4

        [HttpGet("{DBName},{login},{password},{sql}")]
        public IActionResult Post(string DBName, string login, string password, string sql)
        {
            DAOLayer bc = new DAOLayer(sql.Replace("%", " "), DBName, login, password);

            List<Object[]> data = bc.reed();
            byte[] fileContents = ExcelExport.Export(data);

            if (fileContents == null)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: ExcelExport.ContentType,
                fileDownloadName: ExcelExport.FileDownloadName
                );

        }


        //[HttpPost]
        //public IActionResult Post2(
        //    [FromBody]string DBName, 
        //    [FromBody]string login, 
        //    [FromBody]string password, 
        //    [FromBody]string sql)
        //{
        //    DAOLayer bc = new DAOLayer(sql, DBName, login, password);

        //    List<Object[]> data = bc.reed();
        //    byte[] fileContents = ExcelExport.Export(data);

        //    if (fileContents == null)
        //    {
        //        return NotFound();
        //    }

        //    return File(
        //        fileContents: fileContents,
        //        contentType: ExcelExport.ContentType,
        //        fileDownloadName: ExcelExport.FileDownloadName
        //        );

        //}



        //    //-Method POST -Body (@{Login = "root"; Password = "1111"} | ConvertTo-Json) -ContentType "application/json"

        //    [HttpPost]
        //    public IActionResult Post([FromBody] Post post)
        //    {

        //        if(post == null)
        //        {
        //            return BadRequest();
        //        }

        //        return Ok(post);
        //    }

        //}


        //public class Post
        //{
        //    //IBA,root,1111,SELECT%20bookID%20FROM%20books
        //    public Post(string Login, string Password)
        //    {
        //        //this.DBName = DBName;
        //        this.Login = Login;
        //        this.Password = Password;
        //        //this.SQL = SQL;
        //    }

        //    //public string DBName;
        //    public string Login;
        //    public string Password;
        //    //public string SQL;
        //}
    }

}