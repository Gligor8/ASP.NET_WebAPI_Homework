using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIBooks.Models;

namespace WebAPIBooks
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>()
        {
           new Book(){Author = "Stefan Zweig", Title = "The World of Yesterday" },
           new Book(){Author = "William Thackeray", Title = "Vanity Fair" },
           new Book(){Author = "John Galsworthy", Title = "The Forsyte Saga" },
           new Book(){Author = "George Eliot", Title = "The Mill on the Floss" }
        };
    }
}
