using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIWorkshop_MovieApp.Models;
using WebAPIWorkshop_MovieApp.Models.Enums;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieModel> GetAllMovies();
        Movie GetMovieById(int id);
        List<Movie> GetMovieByGenre(Genre genre);
        void AddMovie(MovieModel movie);
        void UpdateMovie(MovieModel movie);
        void DeleteMovie(int id);
    }
}
