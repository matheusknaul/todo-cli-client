using Application.Interfaces;

namespace Application.UseCase.User
{
    public class RequestAuthUseCase
    {
        private readonly ISessionHandler _sessionHandler;

        public RequestAuthUseCase(ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
        }

        public async Task ExecuteAsync(string email)
        {
            try
            { 
                
            }
            catch(Exception ex) 
            { 
            
            }
        }
    }
}
