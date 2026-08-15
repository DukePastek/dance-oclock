using DanceOClock.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanceOClock.Data;

public class DanceOClockDbContext(DbContextOptions<DanceOClockDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Actu> Actus => Set<Actu>();
    public DbSet<GalerieItem> GalerieItems => Set<GalerieItem>();
    public DbSet<PageContent> PageContents => Set<PageContent>();
    public DbSet<ContactRequest> ContactRequests => Set<ContactRequest>();
    public DbSet<SiteSettings> SiteSettings => Set<SiteSettings>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Actu>(e =>
        {
            e.Property(p => p.Title).HasMaxLength(200).IsRequired();
            e.Property(p => p.Type).HasConversion<string>().HasMaxLength(20);
            e.HasIndex(p => new { p.IsPublished, p.PublishedAt });
        });

        builder.Entity<GalerieItem>(e =>
        {
            e.Property(p => p.Title).HasMaxLength(200).IsRequired();
            e.Property(p => p.MediaType).HasConversion<string>().HasMaxLength(20);
            e.Property(p => p.Niveau).HasConversion<string>().HasMaxLength(20);
            e.HasIndex(p => new { p.Niveau, p.DisplayOrder });
        });

        builder.Entity<PageContent>(e =>
        {
            e.Property(p => p.Slug).HasMaxLength(100).IsRequired();
            e.HasIndex(p => p.Slug).IsUnique();
        });

        builder.Entity<ContactRequest>(e =>
        {
            e.Property(p => p.FullName).HasMaxLength(200).IsRequired();
            e.Property(p => p.Email).HasMaxLength(200).IsRequired();
            e.Property(p => p.Status).HasConversion<string>().HasMaxLength(20);
        });
    }
}
