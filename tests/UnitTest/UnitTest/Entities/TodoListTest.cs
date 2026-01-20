using Domain.Entities;
using Domain.Exceptions;

namespace UnitTest.Entities
{
    public class TodoListTest
    {
        [Fact]
        public void CreateDefault_ShouldReturnIsDefaultTrue()
        {
            var todoList = TodoList.CreateDefault(Guid.NewGuid());

            Assert.True(todoList.IsDefault);
        }

        [Fact]
        public void Constructor_ShouldReturnIsDefaultFalse()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);

            Assert.False(todoList.IsDefault);
        }

        [Fact]
        public void AddItem_DuplicateTitle_ShouldThrowDomainException()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);
            var item = new TodoItem(Guid.NewGuid(), "Tarefa 1");

            todoList.AddItem(item);

            Assert.Throws<DomainException>(() => todoList.AddItem(item));
        }

        [Fact]
        public void AddItem_NewItem_ShouldAddSuccessfully()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);
            var item = new TodoItem(Guid.NewGuid(), "Tarefa 1");

            todoList.AddItem(item);

            Assert.Contains(item, todoList.Items);
        }

        [Fact]
        public void DeleteItem_NonExistentItem_ShouldThrowDomainException()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);

            Assert.Throws<DomainException>(() => todoList.DeleteItem(1));
        }

        [Fact]
        public void DeleteItem_ExistingItem_ShouldRemoveSuccessfully()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);
            var item = new TodoItem(Guid.NewGuid(), "Tarefa 1");

            todoList.AddItem(item);
            todoList.DeleteItem(item.TaskNum);

            Assert.DoesNotContain(item, todoList.Items);
        }

        [Fact]
        public void StartFocus_NullTaskNum_ShouldThrowDomainException()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);

            int? taskNum = null;

            Assert.Throws<DomainException>(() => todoList.StartFocus(taskNum));
        }

        [Fact]
        public void StartFocus_AlreadyFocused_ShouldThrowDomainException()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);
            var item = new TodoItem(Guid.NewGuid(), "Tarefa 1");

            todoList.AddItem(item);

            // Primeiro startFocus funciona
            todoList.StartFocus(item.TaskNum);

            // Segundo startFocus para o mesmo item deve lançar exceção
            Assert.Throws<DomainException>(() => todoList.StartFocus(item.TaskNum));
        }

        [Fact]
        public void ItemDoneShouldReturnThrows()
        {
            var todoList = new TodoList(Guid.NewGuid(), "Todo List Test", false);
            var item = new TodoItem(Guid.NewGuid(), "Tarefa 1");

            todoList.AddItem(item);

            // StartFocus deve funcionar
            todoList.StartFocus(item.TaskNum);

            // EndFocus deve funcionar
            todoList.EndFocus(item.TaskNum);

            // Marcar item como Done via método público
            todoList.CompleteItem(item.TaskNum);

            // Agora deve lançar exceção ao tentar StartFocus
            Assert.Throws<DomainException>(() => todoList.StartFocus(item.TaskNum));
        }
    }
}
