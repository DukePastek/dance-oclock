using System.ComponentModel.DataAnnotations;
using DanceOClock.Data.Entities;

namespace DanceOClock.Api.Features.Actus;

public class ActuUpsertRequest
{
    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Summary { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public ActuType Type { get; set; }

    public string? ImageUrl { get; set; }

    public DateTimeOffset PublishedAt { get; set; }

    public bool IsPublished { get; set; }
}
