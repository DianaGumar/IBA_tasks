using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI_7915.Models.Book;
using OfficeOpenXml;
using System.Linq;

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

        //Book/IBA,root,1111,SELECT*FROM%20books%20where%20bookID=4
        //Book/Post? DBName = IBA & login = root & password = 1111 & sql = SELECT * FROM % 20books%20where%20bookID=4

        [HttpGet("{DBName},{login},{password},{sql}")]
        //[HttpPost] // with post isn't work
        public IActionResult Post(string DBName, string login, string password, string sql)
        {
            BookDBController bc = new BookDBController(sql.Replace("%", " "), DBName, login, password);

            List<Book> books = bc.getWhere();

            //Export to excel
            byte[] fileContents;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                #region Header Row
                workSheet.Cells[1, 1].Value = "ID";
                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 2].Value = "Name";
                workSheet.Cells[1, 2].Style.Font.Bold = true;
                workSheet.Cells[1, 3].Value = "Pages";
                workSheet.Cells[1, 3].Style.Font.Bold = true;
                #endregion

                for(int i =0; i < books.Count; i++)
                {
                    #region Header Row
                    workSheet.Cells[i+2, 1].Value = books.ElementAt(i).ID;
                    workSheet.Cells[i+2, 2].Value = books.ElementAt(i).Name;
                    workSheet.Cells[i+2, 3].Value = books.ElementAt(i).Pages;
                    #endregion
                }

                fileContents = package.GetAsByteArray();

            }

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: $"{DateTime.Now.ToString("yyyy.MM.dd")}.xlsx"
                );


        }

    }
}
