using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Homework02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("index")]
        public ActionResult<Book> GetBookByIndex(int index)
        {
            if (index < 0 || index >= StaticDb.Books.Count)
                return NotFound("Book not found");

            return Ok(StaticDb.Books[index]);
        }

        [HttpGet("search")]
        public ActionResult<Book> GetBookByAuthorAndTitle(string author, string title)
        {
            var book = StaticDb.Books.FirstOrDefault(b =>
                b.Author.ToLower() == author.ToLower() &&
                b.Title.ToLower() == title.ToLower());

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book newBook)
        {
            if (newBook == null) return NotFound("Book not added!");
            StaticDb.Books.Add(newBook);

            return StatusCode(StatusCodes.Status201Created, "Book created succesfully");
        }
    }
}
