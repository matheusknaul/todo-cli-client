using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class TodoList
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDefault { get; private set; }
    public List<TodoItem> Items { get; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    
    protected TodoList(){}

    private TodoList(Guid id, string title, bool isInbox)
    {
        Id = id;
        Title = title;
        IsDefault = isInbox;
        Items = new List<TodoItem>();
    }

    public static TodoList CreateDefault(Guid sessionId)
    {
        return new TodoList(
            Guid.NewGuid(),
            "Default",
            true
            );
    }
    
    public void AddItem(TodoItem item)
    {
        if (Items.Any(x => x.Title == item.Title))
            throw new DomainException("Item duplicado");
        
        Items.Add(item);
    }
}