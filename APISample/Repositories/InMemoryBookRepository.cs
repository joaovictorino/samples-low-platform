using CrudSample.Models;

namespace CrudSample.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books =
    [
        new Book
        {
            Id = Guid.Parse("874d290d-350b-4a86-9d26-3bccc55b750d"),
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt & David Thomas",
            YearPublished = 1999
        },
        new Book
        {
            Id = Guid.Parse("d654de78-ee0d-4b7a-a7f6-89e09b248138"),
            Title = "Clean Code",
            Author = "Robert C. Martin",
            YearPublished = 2008
        }
    ];

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

    public Book Add(Book book)
    {
        _books.Add(book);
        return book;
    }

    public Book? Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index == -1)
        {
            return null;
        }

        _books[index] = book;
        return book;
    }

    public bool Delete(Guid id)
    {
        var book = GetById(id);
        if (book is null)
        {
            return false;
        }

        _books.Remove(book);
        return true;
    }
}
