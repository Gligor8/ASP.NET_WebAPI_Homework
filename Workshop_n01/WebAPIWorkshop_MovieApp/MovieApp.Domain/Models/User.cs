using System;
using System.Collections.Generic;
using System.Text;
using WebAPIWorkshop_MovieApp.Models;
using WebAPIWorkshop_MovieApp.Models.Enums;

namespace MovieApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
