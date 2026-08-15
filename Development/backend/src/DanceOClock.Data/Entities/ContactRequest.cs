namespace DanceOClock.Data.Entities;

public enum ContactRequestStatus
{
    New,
    Contacted,
    Closed
}

public class ContactRequest
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public ContactRequestStatus Status { get; set; } = ContactRequestStatus.New;
    public DateTimeOffset CreatedAt { get; set; }
}
