using MovieApp.Models;
using System;
using WebAPIWorkshop_MovieApp.Models;

namespace MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToMovie(this MovieModel movieModel)
        {
            return new Movie
            {
                Id = movieModel.Id,
                Title = movieModel.Title,
                Description = movieModel.Description,
                Year = movieModel.Year,
                Genre = movieModel.Genre
            };
        }

        public static Movie ToMovieModel(this Movie movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre,
                UserId = movie.UserId,
                User = movie.User

            };
        }

    }
}
