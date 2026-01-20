using Application.UseCase.Todo;
using System.CommandLine;
using System.CommandLine.Parsing;

namespace App
{
    public static class CommandBootstrapper
    {
        public static RootCommand BuildCli(TodoListService service)
        {
            var root = new RootCommand("Todo List CLI");

            // create-list
            var createListCmd = new Command("create-list", "Cria uma nova lista de tarefas");

            createListCmd.Add(new Argument<string>("title", "Título da lista"));

            // Associando o comando
            createListCmd.SetAction((parseResult) =>
            {
                var title = parseResult.GetValueForArgument<string>("title");
                var list = service.CreateList(title);
                Console.WriteLine($"Lista criada: {list.Title} (ID: {list.Id})");
            });

            // add-task
            var addTaskCmd = new Command("add-task", "Adiciona uma tarefa a uma lista")
        {
            new Argument<Guid>("listId"),
            new Argument<string>("taskTitle")
        };
            addTaskCmd.Handler = System.CommandLine.Invocation.CommandHandler.Create<Guid, string>((listId, taskTitle) =>
            {
                var list = service.GetListById(listId);
                var item = service.AddTask(list, taskTitle);
                Console.WriteLine($"Tarefa adicionada: {item.Title} (TaskNum: {item.TaskNum})");
            });

            // start-focus
            var startFocusCmd = new Command("start-focus", "Inicia foco em uma tarefa")
        {
            new Argument<Guid>("listId"),
            new Argument<int>("taskNum")
        };
            startFocusCmd.Handler = System.CommandLine.Invocation.CommandHandler.Create<Guid, int>((listId, taskNum) =>
            {
                var list = service.GetListById(listId);
                service.StartFocus(list, taskNum);
                Console.WriteLine($"Foco iniciado na tarefa {taskNum}");
            });

            // Adiciona todos os comandos ao root
            root.AddCommand(createListCmd);
            root.AddCommand(addTaskCmd);
            root.AddCommand(startFocusCmd);

            // Aqui você adicionaria os demais comandos: end-focus, complete-task, remove-task, list-tasks

            return root;
        }
    }
}
