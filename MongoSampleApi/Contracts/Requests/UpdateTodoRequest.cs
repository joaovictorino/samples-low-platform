namespace MongoSampleApi.Contracts.Requests;

public record UpdateTodoRequest(string Title, bool IsCompleted);
