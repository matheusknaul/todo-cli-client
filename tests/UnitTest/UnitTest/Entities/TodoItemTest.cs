using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;

namespace UnitTest.Entities
{
    public class TodoItemTest
    {
        [Fact]
        public void CompleteTaskShouldReturnException()
        {
            var todoItem = new TodoItem(new Guid(), "Todo Item Test",
                 "Test Description");

            // Complete
            todoItem.Complete();

            // Cant complete, return exception
            Assert.Throws<DomainException>(() => todoItem.Complete());
        }
        [Fact]
        public void CompleteTaskShouldReturnSuccess()
        {
            var todoItem = new TodoItem(new Guid(), "Todo Item Test",
                "Test Description");

            todoItem.Complete();

            Assert.Equal(todoItem.Status, TodoStatus.Done);
        }

        [Fact]
        public void RenameTaskShouldReturnNewTitle()
        {
            var todoItem = new TodoItem(new Guid(), "Todo Item Test",
                "Test Description");

            todoItem.Rename("New Title");

            Assert.Equal("New Title", todoItem.Title);
        }

        [Fact]
        public void RenameTaskShouldReturnException()
        {
            var todoItem = new TodoItem(new Guid(), "Todo Item Test",
                "Test Description");

            // Without title, cant rename, should return exception.
            Assert.Throws<DomainException>(() => todoItem.Rename(string.Empty));
        }
    }
}

