using Domain.Entities;

namespace Application.UseCase.Todo.Create
{
    public class CreateTodoItemCommand
    {
        public Guid TodoId { get; set; }
        public Guid SessionId { get; set; }
        public Guid TodoListId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
