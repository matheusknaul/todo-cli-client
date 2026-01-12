using Application.UseCase.Todo.Create;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace UnitTest
{
    public class CreateTodoItemTest
    {
        [Fact]
        public void ShouldReturnTrueAsync()
        {
            var mockRepository = new Mock<ITodoRepository>();

            var repoReturn = new Session
            {

            };

            var command = new CreateTodoItemCommand 
            {
                SessionId = Guid.NewGuid(),
                TodoListId = Guid.NewGuid(),
                Title = "Item Teste"
            };

            var useCase = new CreateTodoItemUseCase(mockRepository.Object);
            
            useCase.ExecuteAsync(command);



        }

        [Fact]
        public void ShouldReturnFalseAsync() 
        {
            var mockRepository = new Mock<ITodoRepository>();


        }
    }
}
