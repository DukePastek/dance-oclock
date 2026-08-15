using DanceOClock.Data.Entities;

namespace DanceOClock.Api.Features.Actus;

public class ActuDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ActuType Type { get; set; }
    public string? ImageUrl { get; set; }
    public DateTimeOffset PublishedAt { get; set; }
    public bool IsPublished { get; set; }
}
