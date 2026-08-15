namespace DanceOClock.Data.Entities;

public class GalerieItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public GalerieMediaType MediaType { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public NiveauDanse Niveau { get; set; }
    public int DisplayOrder { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
