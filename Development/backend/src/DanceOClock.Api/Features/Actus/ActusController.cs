using DanceOClock.Data;
using DanceOClock.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanceOClock.Api.Features.Actus;

[ApiController]
[Route("api/actus")]
public class ActusController(DanceOClockDbContext db) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<ActuDto>>> GetAll()
    {
        var actus = await db.Actus
            .Where(a => a.IsPublished)
            .OrderByDescending(a => a.PublishedAt)
            .Select(a => ToDto(a))
            .ToListAsync();

        return Ok(actus);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<ActuDto>> GetById(Guid id)
    {
        var actu = await db.Actus.FindAsync(id);
        if (actu is null || !actu.IsPublished)
        {
            return NotFound();
        }

        return Ok(ToDto(actu));
    }

    [HttpGet("admin")]
    [Authorize]
    public async Task<ActionResult<List<ActuDto>>> GetAllForAdmin()
    {
        var actus = await db.Actus
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => ToDto(a))
            .ToListAsync();

        return Ok(actus);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ActuDto>> Create(ActuUpsertRequest request)
    {
        var now = DateTimeOffset.UtcNow;
        var actu = new Actu
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Summary = request.Summary,
            Content = request.Content,
            Type = request.Type,
            ImageUrl = request.ImageUrl,
            PublishedAt = request.PublishedAt,
            IsPublished = request.IsPublished,
            CreatedAt = now,
            UpdatedAt = now
        };

        db.Actus.Add(actu);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = actu.Id }, ToDto(actu));
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, ActuUpsertRequest request)
    {
        var actu = await db.Actus.FindAsync(id);
        if (actu is null)
        {
            return NotFound();
        }

        actu.Title = request.Title;
        actu.Summary = request.Summary;
        actu.Content = request.Content;
        actu.Type = request.Type;
        actu.ImageUrl = request.ImageUrl;
        actu.PublishedAt = request.PublishedAt;
        actu.IsPublished = request.IsPublished;
        actu.UpdatedAt = DateTimeOffset.UtcNow;

        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var actu = await db.Actus.FindAsync(id);
        if (actu is null)
        {
            return NotFound();
        }

        db.Actus.Remove(actu);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static ActuDto ToDto(Actu a) => new()
    {
        Id = a.Id,
        Title = a.Title,
        Summary = a.Summary,
        Content = a.Content,
        Type = a.Type,
        ImageUrl = a.ImageUrl,
        PublishedAt = a.PublishedAt,
        IsPublished = a.IsPublished
    };
}
