using Application.Interfaces;

namespace Application.UseCase.CreateTodoItem;

public class CreateTodoItemUseCase
{
    private readonly ISessionHandler _sessionHandler;
    
    public CreateTodoItemUseCase(ISessionHandler sessionHandler)
    {
        _sessionHandler = sessionHandler;
    }
    
    public 
}