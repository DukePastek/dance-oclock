using System.ServiceModel.Syndication;
using System.Xml;
using DanceOClock.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanceOClock.Api.Features.Rss;

[ApiController]
[Route("api/rss")]
[AllowAnonymous]
public class RssController(DanceOClockDbContext db, IConfiguration configuration) : ControllerBase
{
    [HttpGet("actus")]
    public async Task<IActionResult> GetActusFeed()
    {
        var siteUrl = configuration["SiteUrl"] ?? $"{Request.Scheme}://{Request.Host}";

        var actus = await db.Actus
            .Where(a => a.IsPublished)
            .OrderByDescending(a => a.PublishedAt)
            .Take(50)
            .ToListAsync();

        var feed = new SyndicationFeed(
            "Dance O'Clock - Actus & bons plans",
            "Les dernières actus, promos et bons plans de Dance O'Clock",
            new Uri(siteUrl),
            "dance-oclock-actus",
            actus.Count > 0 ? actus.Max(a => a.UpdatedAt).UtcDateTime : DateTime.UtcNow)
        {
            Items = actus.Select(a => new SyndicationItem(
                a.Title,
                a.Summary,
                new Uri($"{siteUrl}/actu/{a.Id}"),
                a.Id.ToString(),
                a.UpdatedAt)
            {
                PublishDate = a.PublishedAt
            })
        };

        await using var stream = new MemoryStream();
        await using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { Async = true, Encoding = System.Text.Encoding.UTF8 }))
        {
            var rssFormatter = new Rss20FeedFormatter(feed);
            rssFormatter.WriteTo(xmlWriter);
            await xmlWriter.FlushAsync();
        }

        return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
    }
}
