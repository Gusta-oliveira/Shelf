using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Edition { get; set; }

        public Book(string t, string a, string i, string e)
        {
            this.Title = t;
            this.Author = a;
            this.Isbn = i;
            this.Edition = e;
        }
        public Book()
        {
            
        }
        public override string ToString()
        {
            return Title+ ", " + Author + ", " + Edition + ", " + Isbn;
        }
    }
}
