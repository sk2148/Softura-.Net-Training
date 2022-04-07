using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Lynq
{
    class Day24Task
    {
        public static void Main()
        {
            IList<Book> BookData = new List<Book>()
            {
                new Book(){BookID=1,BookName="The Match",AuthorName="Harlan Coben",BookPrice=1000},
                new Book(){BookID=2,BookName="The Atlas Six",AuthorName="Olivie Blake",BookPrice=1200},
                new Book(){BookID=3,BookName="The Midnight Library",AuthorName="Matt Haig",BookPrice=900},
                new Book(){BookID=4,BookName="The Lighting Rod",AuthorName="Brad Meltzer ",BookPrice=750}
            };
            var bkqry = from b in BookData
                     select b;
            Console.WriteLine("1.Display All Data");
            foreach (var v in bkqry)
                Console.WriteLine("BookId:"+v.BookID+"|Name:"+v.BookName+" |Author: "+v.AuthorName+" |Price:"+v.BookPrice);
            Console.WriteLine("**********************************");
            Console.WriteLine("2.Books By Particular Author");
            var bkqry1 = from b1 in BookData
                         where b1.AuthorName.Contains("Brad Meltzer")
                         select b1;
            foreach (var v2 in bkqry1)
                Console.WriteLine(v2.BookName);
            Console.WriteLine("**********************************");
            Console.WriteLine("3.Display price Lowest to Highest");
            var bkqry2 = BookData.OrderBy(s => s.BookPrice);
            foreach (var v3 in bkqry2)
                Console.WriteLine(v3.BookName+"Price:"+v3.BookPrice);
            Console.WriteLine("**********************************");
            Console.WriteLine("4.Books by Author in Ascending Order");
            var bkqry3 = from boks in BookData
                         orderby boks.AuthorName
                         select boks;
            foreach (var v1 in bkqry3)
                Console.WriteLine(v1.AuthorName+"|Book Title:"+v1.BookName);
        }
    }
    class Book
    {
        public int BookID{ get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public float BookPrice { get; set; }
    }
}
