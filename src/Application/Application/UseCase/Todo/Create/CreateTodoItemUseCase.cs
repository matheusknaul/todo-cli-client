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
                var session = _repo.LoadAsync();


            }
            catch (Exception ex) 
            {
            
            }
        }
    }
}
