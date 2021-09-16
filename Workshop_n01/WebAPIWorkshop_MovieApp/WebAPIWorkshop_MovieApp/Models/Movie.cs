using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWorkshop_MovieApp.Models.Enums;

namespace WebAPIWorkshop_MovieApp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
