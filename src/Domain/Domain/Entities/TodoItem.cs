using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class TodoItem
{
    public Guid Id { get; }
    public Guid SessionId { get; }
    public Guid VersionId { get; }
    public int TaskNum { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TodoStatus Status { get; private set; }
    public int ElapsedMinutes  { get; private set; }
    public DateTime CreatedAt { get;}
    public DateTime UpdatedAt { get; private set; }
    public DateTime ClosedAt { get; private set; }
    
    public TodoItem(Guid id, string title, string description = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Título obrigatório");

        Id = id;
        Title = title;
        Description = description;
        Status = TodoStatus.InProgress;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public void Complete()
    {
        if(Status == TodoStatus.Done)
            throw new DomainException("TodoItem já concluído.");
        Status = TodoStatus.Done;
        ClosedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new DomainException("Título obrigatório");
        
        Title = newTitle;
        UpdatedAt = DateTime.UtcNow;
    }
}