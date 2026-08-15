using Microsoft.AspNetCore.Identity;

namespace DanceOClock.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
}
