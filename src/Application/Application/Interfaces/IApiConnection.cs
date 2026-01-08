using Domain.Entities;

namespace Application.Interfaces;

public interface IApiConnection
{
    Task<Session> ValidateVerificationCodeAsync(string code);
    Task RequestVersionAsync();
    Task<bool> UpdateVersionAsync(Session session);
}