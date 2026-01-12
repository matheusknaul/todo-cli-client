namespace Domain.Entities;

public class Session
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid VersionId { get; set; }
    public Version Version { get; set; } = new();
    public DateTime SessionDate { get; set; }
}