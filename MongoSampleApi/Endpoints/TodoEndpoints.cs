using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using MongoSampleApi.Contracts.Requests;
using MongoSampleApi.Services;

namespace MongoSampleApi.Endpoints;

public static class TodoEndpoints
{
    public static RouteGroupBuilder MapTodoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/todos");
        group.WithTags("Todos");
        group.WithOpenApi();

        group.MapGet("/", async ([FromServices] TodoService service, CancellationToken cancellationToken) =>
        {
            var todos = await service.GetAsync(cancellationToken);
            return Results.Ok(todos);
        });

        group.MapGet("/completed", async ([FromServices] TodoService service, CancellationToken cancellationToken) =>
        {
            var completedTodos = await service.GetCompletedAsync(cancellationToken);
            return Results.Ok(completedTodos);
        })
        .WithName("GetCompletedTodos");

        group.MapGet("/{id}", async ([FromServices] TodoService service, string id, CancellationToken cancellationToken) =>
        {
            var todo = await service.GetByIdAsync(id, cancellationToken);
            return todo is null ? Results.NotFound() : Results.Ok(todo);
        })
        .WithName("GetTodoById");

        group.MapPost("/", async ([FromServices] TodoService service, CreateTodoRequest request, CancellationToken cancellationToken) =>
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Results.BadRequest(new { error = "Title is required." });
            }

            var todo = await service.CreateAsync(request, cancellationToken);
            return Results.Created($"/api/todos/{todo.Id}", todo);
        });

        group.MapPut("/{id}", async ([FromServices] TodoService service, string id, UpdateTodoRequest request, CancellationToken cancellationToken) =>
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Results.BadRequest(new { error = "Title is required." });
            }

            var updated = await service.UpdateAsync(id, request, cancellationToken);
            return updated ? Results.NoContent() : Results.NotFound();
        });

        group.MapDelete("/{id}", async ([FromServices] TodoService service, string id, CancellationToken cancellationToken) =>
        {
            var deleted = await service.DeleteAsync(id, cancellationToken);
            return deleted ? Results.NoContent() : Results.NotFound();
        });

        return group;
    }
}
