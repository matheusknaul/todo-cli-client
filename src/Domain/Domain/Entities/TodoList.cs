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

    protected TodoList() { }

    public TodoList(Guid id, string title, bool isDefault)
    {
        Id = id;
        Title = title;
        IsDefault = isDefault;
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

        int lastNumber = Items.Any() ? Items.Max(i => i.TaskNum) : 0;

        item.TaskNum = lastNumber + 1;

        Items.Add(item);
    }

    public void DeleteItem(int taskNum)
    {
        if (!Items.Any(X => X.TaskNum == taskNum))
            throw new DomainException("Item n�o encontrado");

        Items.Remove(Items.FirstOrDefault(X => X.TaskNum == taskNum));
    }

    public void StartExecution(int? taskNum)
    {
        if (!taskNum.HasValue)
            throw new DomainException("TaskNum n�o pode ser nulo");

        var todoItem = Items.FirstOrDefault(t => t.TaskNum == taskNum.Value);

        if (todoItem == null)
            throw new DomainException("Item n�o encontrado");

        switch (todoItem.Status)
        {
            case TodoStatus.InProgress:
                throw new DomainException("Item j� est� em foco");
            case TodoStatus.Done:
                throw new DomainException("Item j� est� finalizado");
        }

        todoItem.Status = TodoStatus.InProgress;
        todoItem.ElapsedMinutes.Start();
    }

    public void CompleteItem(int taskNum)
    {
        var todoItem = Items.FirstOrDefault(t => t.TaskNum == taskNum)
            ?? throw new DomainException("Item n�o encontrado");

        if (todoItem.Status == TodoStatus.Done)
            throw new DomainException("Item j� finalizado");

        todoItem.Status = TodoStatus.Done;
    }


    public void EndExecution(int taskNum)
    {
        var todoItem = Items.FirstOrDefault(t => t.TaskNum == taskNum);

        if (todoItem == null)
            throw new DomainException("Item não encontrado");

        if (todoItem.Status == TodoStatus.Open ||
            todoItem.Status == TodoStatus.Done)
            throw new DomainException("Item não está em focus");

        todoItem.Status = TodoStatus.Open;
        todoItem.ElapsedMinutes.Finish();

    }
}