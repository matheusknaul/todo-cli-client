namespace Infrastructure.Handler;

public class SessionOptions
{
    public string SessionPath { get; set; }
    public string SessionKey { get; set; }
    public string VersionPath { get; set; }
    public string SessionHistoryPath { get; set; }
}