using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting book with id: {id}", id);
            var book = _bookService.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with id: {id} not found", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book)
        {
            _logger.LogInformation("Creating new book");
            var createdBook = _bookService.Create(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to create book");
                return NotFound();
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating book with id: {id}", book.Id);
            var updatedBook = _bookService.Update(book);
            if (updatedBook == null)
            {
                _logger.LogError("Failed to update book with id: {id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book with id: {id} updated successfully", book.Id);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with id: {id}", id);
            _bookService.Delete(id);
            _logger.LogDebug("Book with id: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
