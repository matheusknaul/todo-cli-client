using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Integration;
using Microsoft.Extensions.Options;
using Version = System.Version;

namespace Infrastructure.Handler;

public sealed class SessionHandler : ISessionHandler
{
    private readonly Session _session;
    private readonly Version _version;
    private readonly IApiConnection _apiConnection;

    public SessionHandler(IOptions<SessionOptions> options, IApiConnection apiConnection)
    {
        _session = InitializeSession(options.Value.SessionPath);
        _version = LoadVersion(options.Value.VersionPath);
        
        _apiConnection = apiConnection;
    }
    
    public async Task<bool> SyncSessionAsync(string token)
    {
        var request = await _apiConnection.SyncSessionAsync(token);
    }

    private Session InitializeSession(string sessionPath)
    {
        return _session;
    }

    private Version LoadVersion(string versionPath)
    {
        return _version;
    }
    
    
}