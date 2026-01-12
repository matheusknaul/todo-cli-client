using Application.UseCase.Todo.Create;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using UnitTest.CommonUtilitiesTest;
using Version = Domain.Entities.Version;

namespace UnitTest
{
    public class CreateTodoItemTest
    {
        [Fact]
        public async Task ShouldReturnTrueAsync()
        {
            // Arrange
            var fakeRepository = new SessionRepositoryTest();

            var session = new Session();

            var guidTodo = Guid.NewGuid();

            session.Version = new Version
            {
                TodoLists = new List<TodoList>
                {
                    new TodoList{ Id = guidTodo}
                }
            };

            fakeRepository.CreateSessionJson(session);

            var command = new CreateTodoItemCommand
            {
                SessionId = Guid.NewGuid(),
                TodoListId = guidTodo,
                Title = "Item Teste"
            };

            var useCase = new CreateTodoItemUseCase(fakeRepository);

            // Act
            await useCase.ExecuteAsync(command);

            var result = await fakeRepository.LoadAsync();

            // Assert
            var todoList = result.Version.TodoLists
                .FirstOrDefault(x => x.Id == command.TodoListId);

            Assert.NotNull(todoList);

            Assert.Contains(todoList.Items, item =>
                item.Title == command.Title
            );
        }

        [Fact]
        public void ShouldReturnFalseAsync() 
        {
            var mockRepository = new Mock<ITodoRepository>();


        }
    }
}
