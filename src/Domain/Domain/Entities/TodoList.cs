using Domain.Enums;

namespace Domain.Entities;

public class TodoList
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid VersionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TodoStatus Status { get; set; }
    public List<TodoItem> Items { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
}