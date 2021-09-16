using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWorkshop_MovieApp.Models;
using WebAPIWorkshop_MovieApp.Models.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIWorkshop_MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET: api/<MovieController>  - get movie by id
        [HttpGet ("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Movie Id cannot be an integer below zero");
                }
                if (id >= StaticDB.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Nonexistent id");
                }
                return StatusCode(200, StaticDB.Movies[id]);
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("genre/{genre}")]
        public ActionResult<Movie> GetGenre(Genre genre)
        {
            try
            {
                Movie movieSearch = StaticDB.Movies.FirstOrDefault(x => x.Genre == genre);
                return StatusCode(StatusCodes.Status200OK, movieSearch); 
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

//        POST api/<MovieController>
        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            try
            {
                StaticDB.Movies.Add(movie);
                return StatusCode(StatusCodes.Status201Created, "New movie added");
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");

            }
        }

        // Get All Movies
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDB.Movies);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("movieDel/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                StaticDB.Movies.RemoveAt(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut("{movieIndex}")]
        public IActionResult PutMovie(int movieIndex, [FromBody] int year)
        {
            try
            {
                if (movieIndex < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }
                if (movieIndex >= StaticDB.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Movie does not exist");
                }

                Movie film = StaticDB.Movies[movieIndex];
                if (film != null)
                {
                    StaticDB.Movies.FirstOrDefault(x => x.Year.Equals(year));

                }
                return StatusCode(StatusCodes.Status200OK, "Year has been overwritten");
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
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
