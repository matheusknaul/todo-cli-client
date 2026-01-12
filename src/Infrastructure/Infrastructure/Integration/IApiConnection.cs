using Domain.Entities;
using Refit;

namespace Infrastructure.Integration;

public interface IApiConnection
{
    [Post("/request-auth")]
    Task RequestAuthAsync();

    [Post("/request-auth")]
    Task RequestAuthAsync([Body]string email);
    [Post("/update-data")]
    Task<string> UpdateDataASync(Session session);
    [Get("/sync-session")]
    Task<ApiResponse<Session>> SyncSessionAsync(string token);
    Task<string> RegisterUserAsync(string username, string email);
    Task<string> ValidateCodeAsync(string code);
}