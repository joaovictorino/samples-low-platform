namespace CrudSample.Models;

public record Book
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public int YearPublished { get; init; }
}
