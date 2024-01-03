using HttpClientDemo.Api.Data;
using HttpClientDemo.Api.Entities;
using HttpClientDemo.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HttpClientDemo.Api.Routes;

public static class TodoRoutes
{
    public static void MapTodoRoutes(this WebApplication app)
    {
        app.MapGet("/todo-items", async (AppDbContext db) =>
                await db.Todos.Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Name,
                    IsComplete = t.IsComplete
                }).ToListAsync()
            )
            .WithName("todoItems")
            .WithOpenApi();

        app.MapGet("/todo-items/complete", async (AppDbContext db) =>
                await db.Todos.Where(t => t.IsComplete).Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Name,
                    IsComplete = t.IsComplete
                }).ToListAsync())
            .WithName("completedTodoItems")
            .WithOpenApi();


        app.MapGet("/todo-items/{id}", async (int id, AppDbContext db) =>
                await db.Todos.FindAsync(id)
                    is Todo todo
                    ? Results.Ok(todo)
                    : Results.NotFound())
            .WithName("getById")
            .WithOpenApi();

        app.MapPost("/todo-items", async (CreateTodoRequest request, AppDbContext db) =>
            {
                var todo = Todo.CreateInstance(request.Name);
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/todo-items/{todo.Id}", new TodoResponse
                {
                    Id = todo.Id,
                    Title = todo.Name,
                    IsComplete = todo.IsComplete
                });
            })
            .WithName("createTodoItem")
            .WithOpenApi();

        app.MapPut("/todo-items/{id}", async (int id, UpdateTodoRequest inputTodo, AppDbContext db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("updateTodoItem")
            .WithOpenApi();

        app.MapDelete("/todo-items/{id}", async (int id, AppDbContext db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            })
            .WithName("deleteTodoItem")
            .WithOpenApi();
    }
}