namespace Api.Models.Requests;

public class BulkCreateTodoRequest
{
    public List<CreateTodoRequest> Items { get; set; } = [];
}
