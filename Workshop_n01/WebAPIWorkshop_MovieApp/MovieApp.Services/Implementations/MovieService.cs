//using static MovieApp.DataAccess.Interfaces.IRepository;
using MovieApp.DataAccess;
using MovieApp.Domain.Models;
using MovieApp.Mappers;
using MovieApp.Models;
using MovieApp.Services.Interfaces;
using MovieApp.Shared;
using MovieApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Core.Persistence.Repositories;
using WebAPIWorkshop_MovieApp.Models;
using WebAPIWorkshop_MovieApp.Models.Enums;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;
        private IUserRepository _userRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void AddMovie(MovieModel movieModel)
        {
           

            if (string.IsNullOrEmpty(movieModel.Title))
            {
                throw new MovieException("The property Title for movie is required");
            }
            if (movieModel.Title.Length > 50)
            {
                throw new MovieException("The property Title can't contain more than 50 characters");
            }
            if (movieModel.Description.Length > 100)
            {
                throw new MovieException("The property Description can't contain more than 100 characters");
            }


            Movie movieForDb = movieModel.ToMovie();
            _movieRepository.Add(movieForDb);
        }

        public void DeleteMovie(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);
            if (movieDb == null)
            {
                throw new MovieException("Movie not found!");
            }

            _movieRepository.Delete(movieDb);
        }

        public List<MovieModel> GetAllMovies()
        {
            List<Movie> getAllMovies = _movieRepository.GetAll();
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (Movie movie in getAllMovies)
            {
                movieModels.Add(movie.ToMovieModel());
            }
            return movieModels;
        }

        public List<Movie> GetMovieByGenre(Genre genre)
        {
            List<Movie> allMovies = _movieRepository.GetAll();
            List<Movie> genreOfMovies = (List<Movie>)allMovies.Where(x => x.Genre == genre);
            return genreOfMovies;
        }

       
        public Movie GetMovieById(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);
            if (movieDb == null)
            {
                throw new NotFoundException($"Movie with an id {id} cannot be found");
            };
            return movieDb.ToMovieModel();
        }

        public void UpdateMovie(MovieModel movieModel)
        {
            Movie movieDb = _movieRepository.GetById(movieModel.Id);
            if (movieDb.Equals(null))
            {
                throw new MovieException($"Movie with an id {movieModel.Id} cannot be found!");
            }
            if (string.IsNullOrEmpty(movieModel.Description))
            {
                throw new MovieException("This property cannot be left empty!");
            }
            if (movieModel.Description.Length > 500)
            {
                throw new MovieException("The Description cannot exceed 500 characters");
            }
            if (movieModel.Year > 2021 || movieModel.Year < 1899)
            {
                throw new MovieException("No movie has ever been produced in that year");
            }

            movieDb.Title = movieModel.Title;
            movieDb.Description = movieModel.Description;
            movieDb.Year = movieModel.Year;
            movieDb.Genre = movieModel.Genre;
            movieDb.UserId = movieDb.UserId;
            _movieRepository.Update(movieDb);
        }

        
    }
}
