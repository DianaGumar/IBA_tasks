using Export;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebAPI_7915.Models.DataBase;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {

        //medicine_full,root,1111,SELECT* FROM%20applyings
        // IBA,root,1111,SELECT*FROM%20books
        //   IBA,root,1111,SELECT%20bookID%20FROM%20books     

        [HttpGet("{DBName},{login},{password},{sql}")]
        public IActionResult Get(string DBName, string login, string password, string sql)
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


        // Post?DBName=IBA&login=root&password=1111&sql=SELECT*FROM%20books
        
        public IActionResult Post([FromBody] Data dataUser)
        //public IActionResult Post2([FromHeader]string DBName, [FromHeader]string login, [FromHeader]string password, [FromHeader]string sql)
        {
            DAOLayer bc = new DAOLayer(dataUser.SQL, dataUser.DBName, dataUser.Login, dataUser.Password);
            //DAOLayer bc = new DAOLayer(sql, DBName, login, password);

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

    }
}
