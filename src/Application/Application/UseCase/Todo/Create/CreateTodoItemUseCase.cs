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
            try
            {
                var session = await _repo.LoadAsync();

                var todoList = session.Version.TodoLists
                    .FirstOrDefault(t => t.Id == command.TodoListId);

                var item = new TodoItem 
                {
                    Title = command.Title,
                    Description = command.Description,
                };

                todoList.Items.Add(item);

                await _repo.SaveAsync(session);

            }
            catch (Exception ex) 
            {
            
            }
        }
    }
}
