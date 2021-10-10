using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Domain;
using MovieApp.Mappers;
using MovieApp.Models;
using MovieApp.Services.Interfaces;
using MovieApp.Shared;
using MovieApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWorkshop_MovieApp.Models;
using WebAPIWorkshop_MovieApp.Models.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIWorkshop_MovieApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: api/<MovieController>  - get movie by id
        [HttpGet ("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            try
            {
                //if (id < 0)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, "Movie Id cannot be an integer below zero");
                //}
                //if (id >= StaticDB.Movies.Count)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, "Nonexistent id");
                //}
                return StatusCode(200, _movieService.GetMovieById(id));
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("genre/{genre}")]
        public ActionResult<MovieModel> GetGenre(Genre genre)
        {
            try
            {
                MovieModel movieSearch = _movieService.GetMovieByGenre(genre);
                

                return StatusCode(StatusCodes.Status200OK, movieSearch); 
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

//        POST api/<MovieController>
        [HttpPost("postmovie")]
        public IActionResult PostMovie([FromBody] MovieModel movie)
        {
            try
            {
                _movieService.AddMovie(movie);
                return StatusCode(StatusCodes.Status201Created, "New movie added");
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");

            }
        }

        // Get All Movies
        [HttpGet]
        public ActionResult<List<MovieModel>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, _movieService.GetAllMovies());
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("movieDel/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]
        public IActionResult PutMovie([FromBody] MovieModel movieModel)
        {
            try
            {
                //if (movieId < 0)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                //}
                //if (movieId >= _movieService.UpdateMovie(movieId))
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, "Movie does not exist");
                //}

                _movieService.UpdateMovie(movieModel);
                return StatusCode(StatusCodes.Status204NoContent, "Movie updated");
            }
            catch(NotFoundException e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            catch(MovieException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

        // POST api/<MovieController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<MovieController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<MovieController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
