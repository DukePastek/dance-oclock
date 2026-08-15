using DanceOClock.Api.Options;
using DanceOClock.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DanceOClock.Api.Services;

public class AdminSeeder(
    UserManager<ApplicationUser> userManager,
    IOptions<List<AdminAccountOptions>> adminAccounts,
    ILogger<AdminSeeder> logger)
{
    public async Task SeedAsync()
    {
        foreach (var account in adminAccounts.Value)
        {
            if (string.IsNullOrWhiteSpace(account.Email) || string.IsNullOrWhiteSpace(account.Password))
            {
                continue;
            }

            var existing = await userManager.FindByEmailAsync(account.Email);
            if (existing is not null)
            {
                continue;
            }

            var user = new ApplicationUser
            {
                UserName = account.Email,
                Email = account.Email,
                DisplayName = account.DisplayName,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                logger.LogError("Failed to seed admin account {Email}: {Errors}", account.Email,
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
