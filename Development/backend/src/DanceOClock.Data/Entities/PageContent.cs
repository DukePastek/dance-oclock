namespace DanceOClock.Data.Entities;

public class PageContent
{
    public Guid Id { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string BodyHtml { get; set; } = string.Empty;
    public DateTimeOffset UpdatedAt { get; set; }
}
