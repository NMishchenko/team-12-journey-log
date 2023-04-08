using Microsoft.AspNetCore.Identity;

namespace JourneyLog.DAL.Entities;

public class User: IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
}