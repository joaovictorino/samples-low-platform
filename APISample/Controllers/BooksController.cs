using CrudSample.Contracts;
using CrudSample.Models;
using CrudSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        var books = _bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Book> GetBook(Guid id)
    {
        var book = _bookService.GetBook(id);
        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Book> CreateBook(CreateBookRequest request)
    {
        var created = _bookService.CreateBook(request);
        return CreatedAtAction(nameof(GetBook), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Book> UpdateBook(Guid id, UpdateBookRequest request)
    {
        var updated = _bookService.UpdateBook(id, request);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook(Guid id)
    {
        var deleted = _bookService.DeleteBook(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
