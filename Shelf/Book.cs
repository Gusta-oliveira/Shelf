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
        public long Isbn { get; set; }
        public int Edition { get; set; }

        public Book(string t, string a, long i, int e)
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
            return $"Title: {Title} |Author: {Author} |Edition: {Edition}| Isbn: {Isbn}";
        }
        public string ToFile()
        {
            return Title + ", " + Author + ", " + Edition + ", " + Isbn;
        }
    }
}
