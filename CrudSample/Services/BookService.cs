using CrudSample.Contracts;
using CrudSample.Models;
using CrudSample.Repositories;

namespace CrudSample.Services;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Book> GetBooks() => _repository.GetAll();

    public Book? GetBook(Guid id) => _repository.GetById(id);

    public Book CreateBook(CreateBookRequest request)
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Author = request.Author,
            YearPublished = request.YearPublished
        };

        return _repository.Add(book);
    }

    public Book? UpdateBook(Guid id, UpdateBookRequest request)
    {
        var existing = _repository.GetById(id);
        if (existing is null)
        {
            return null;
        }

        var updated = existing with
        {
            Title = request.Title,
            Author = request.Author,
            YearPublished = request.YearPublished
        };

        return _repository.Update(updated);
    }

    public bool DeleteBook(Guid id) => _repository.Delete(id);
}
