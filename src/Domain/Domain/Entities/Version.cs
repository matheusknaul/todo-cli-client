namespace Domain.Entities;

public class Version
{
    public Guid Id { get; private set; }
    public List<TodoList> TodoLists { get; private set; } = new();

    public TodoList GetDefault()
    {
        var inbox = TodoLists.FirstOrDefault(x => x.IsDefault);
        
        if(inbox != null)
            return inbox;

        inbox = TodoList.CreateDefault(Id);
        TodoLists.Add(inbox);
        return inbox;
    }

    public TodoList GetOrDefault(Guid todoListId)
    {
        return TodoLists.FirstOrDefault(x => x.Id == todoListId)
            ?? GetDefault();
    }
    
}