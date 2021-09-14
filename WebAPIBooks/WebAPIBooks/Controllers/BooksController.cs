using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult <IEnumerable<Book>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDB.Books);
        }

        [HttpGet("queryString")]
        public ActionResult GetByQueryString(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }

                if (index >= StaticDB.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDB.Books[index]);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("multipleQuery")]
        public ActionResult<Book> GetBookByFiltering( string author, string title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                if (string.IsNullOrEmpty(author))
                {
                    Book book = StaticDB.Books.FirstOrDefault(x => x.Author.Contains(author));
                    if (book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "book not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }

                if (string.IsNullOrEmpty(title))
                {
                    Book book = StaticDB.Books.FirstOrDefault(x => x.Title.Contains(title));
                    if (book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "book not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }

                Book bookDb = StaticDB.Books.FirstOrDefault(x => x.Author.Equals(author) && x.Title.Equals(title));

                if (bookDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "book not found");
                }
                return StatusCode(StatusCodes.Status200OK, bookDb);
            }
            catch { 

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //// GET api/<BooksController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<BooksController>
        [HttpPost("BookAdd")]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                StaticDB.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "A new book added!");
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpPost("PostList")]
        public IActionResult PostTitle([FromBody] List<Book> titles)
        {
            List<string> titleList = StaticDB.Books.FirstOrDefault(x => x.Title.Equals(titles));
            return StatusCode(StatusCodes.Status201Created, titleList);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
