namespace DanceOClock.Api.Options;

public class AdminAccountOptions
{
    public const string SectionName = "AdminAccounts";

    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}
