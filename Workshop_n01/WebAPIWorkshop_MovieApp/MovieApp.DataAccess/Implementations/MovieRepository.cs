using Microsoft.EntityFrameworkCore;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPIWorkshop_MovieApp.Models;

namespace MovieApp.DataAccess.Implementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieAppDbContext _notesAppDbContext;
        public MovieRepository(MovieAppDbContext movieAppDbContext)
        {
            _notesAppDbContext = movieAppDbContext;
        }
        public void Add(Movie entity)
        {
            _notesAppDbContext.Movies.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _notesAppDbContext.Movies.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _notesAppDbContext
                .Movies
                .ToList();
        }

        public Movie GetById(int id)
        {
            return _notesAppDbContext
                .Movies
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie entity)
        {
            _notesAppDbContext.Movies.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}
