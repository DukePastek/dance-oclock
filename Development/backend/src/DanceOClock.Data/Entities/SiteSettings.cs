namespace DanceOClock.Data.Entities;

public class SiteSettings
{
    public int Id { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? TiktokUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? NewsletterUrl { get; set; }
    public string? GoogleReviewUrl { get; set; }
    public string? Address { get; set; }
    public double? MapLatitude { get; set; }
    public double? MapLongitude { get; set; }
}
