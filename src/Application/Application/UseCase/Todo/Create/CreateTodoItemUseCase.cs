using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCase.Todo.Create
{
    public class CreateTodoItemUseCase
    {
        private readonly ITodoRepository _repo;

        public CreateTodoItemUseCase (ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task ExecuteAsync(CreateTodoItemCommand command)
        {
            var session = await _repo.LoadAsync();

            var todoList = session.Version
                .GetOrDefault(command.TodoListId);

            var item = new TodoItem(
                command.TodoId,
                command.Title,
                command.Description
            );

            todoList.AddItem(item);

            await _repo.SaveAsync(session);

        }
    }
}
