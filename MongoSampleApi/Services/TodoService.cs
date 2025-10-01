using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoSampleApi.Configuration;
using MongoSampleApi.Contracts.Requests;
using MongoSampleApi.Models;

namespace MongoSampleApi.Services;

public class TodoService
{
    private readonly IMongoCollection<TodoItem> _collection;

    public TodoService(IMongoClient client, IOptions<MongoOptions> options)
    {
        var mongoOptions = options.Value;
        var database = client.GetDatabase(mongoOptions.DatabaseName);
        _collection = database.GetCollection<TodoItem>(mongoOptions.CollectionName);
    }

    public async Task<IReadOnlyList<TodoItem>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _collection.Find(FilterDefinition<TodoItem>.Empty)
            .SortByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<TodoItem?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TodoItem> CreateAsync(CreateTodoRequest request, CancellationToken cancellationToken = default)
    {
        var todo = new TodoItem
        {
            Title = request.Title.Trim(),
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await _collection.InsertOneAsync(todo, cancellationToken: cancellationToken);
        return todo;
    }

    public async Task<bool> UpdateAsync(string id, UpdateTodoRequest request, CancellationToken cancellationToken = default)
    {
        var updateDefinition = Builders<TodoItem>.Update
            .Set(x => x.Title, request.Title.Trim())
            .Set(x => x.IsCompleted, request.IsCompleted);

        var result = await _collection.UpdateOneAsync(x => x.Id == id, updateDefinition, cancellationToken: cancellationToken);
        return result.MatchedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var result = await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
        return result.DeletedCount > 0;
    }
}
