using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_7915.Models
{
    //класс-модель таблицы из бд
    public class Book
    {

        public Book(int ID, string Name, int Pages)
        {
            this.ID = ID;
            this.Name = Name;
            this.Pages = Pages;
        }


        int ID;
        string Name;
        int Pages;


        public override string ToString()
        {
            return "ID = " + ID + "  Name = " + Name + " Pages =  " + Pages;
        }

    }
}
