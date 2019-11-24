using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_7915.Models.Book
{
    //klass-model from data base table
    public class Book
    {

        public Book(string Name, int Pages)
        {
            this.Name = Name;
            this.Pages = Pages;
        }

        public Book(int ID, string Name, int Pages)
        {
            this.ID = ID;
            this.Name = Name;
            this.Pages = Pages;
        }


        public int ID { get; }
        public string Name { get; }
        public int Pages { get; }


        public override string ToString()
        {
            return "ID = " + ID + "  Name = " + Name + " Pages =  " + Pages;
        }

    }
}
