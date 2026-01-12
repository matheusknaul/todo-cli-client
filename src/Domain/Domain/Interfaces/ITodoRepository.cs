using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Session> LoadAsync();
        Task SaveAsync(Session session);
    }
}
