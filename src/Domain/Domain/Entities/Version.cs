namespace Domain.Entities;

public class Version
{
    public Guid Id { get; private set; }
    private readonly List<TodoList> _todoLists = new();
    public IReadOnlyCollection<TodoList> TodoLists => _todoLists;

    public TodoList GetDefault()
    {
        var inbox = TodoLists.FirstOrDefault(x => x.IsDefault);
        
        if(inbox != null)
            return inbox;

        inbox = TodoList.CreateDefault(Id);
        _todoLists.Add(inbox);
        return inbox;
    }

    public TodoList GetOrDefault(Guid todoListId)
    {
        return TodoLists.FirstOrDefault(x => x.Id == todoListId)
            ?? GetDefault();
    }

    public void CreateTodoList(string Title, string description = null)
    {

    }

    public void AddTodoList(TodoList todoList)
    {
        if (todoList == null)
            throw new ArgumentNullException(nameof(todoList));

        if (_todoLists.Any(t => t.Id == todoList.Id))
            return;

        _todoLists.Add(todoList);
    }

    
}