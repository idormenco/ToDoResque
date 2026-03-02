using Api.Extensions;
using Api.Models.Requests;
using Api.Models.Responses;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController(TodoDbContext db) : ControllerBase
{
    /// <summary>Get all todo items.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<TodoItemModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TodoItemModel>>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>Get a todo item by id.</summary>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(TodoItemModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoItemModel>> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create a new todo item.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(TodoItemModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItemModel>> Create([FromBody] CreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        var userId = HttpContext.GetUserId();
        if (userId is null)
            return Unauthorized();

        var item = new TodoItem
        {
            Name = request.Name,
            UserId = userId.Value
        };
        db.TodoItems.Add(item);
        await db.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    /// <summary>Update an existing todo item.</summary>
    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(TodoItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoItemModel>> Update(long id, [FromBody] UpdateTodoRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>Delete a todo item.</summary>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>Mark a todo item as complete.</summary>
    [HttpPatch("{id:long}/complete")]
    [ProducesResponseType(typeof(TodoItemModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoItemModel>> Complete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>Create multiple todo items in one request.</summary>
    [HttpPost("bulk")]
    [ProducesResponseType(typeof(List<TodoItemModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<TodoItemModel>>> BulkCreate([FromBody] BulkCreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}