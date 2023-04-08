using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL;

public class JourneyLogContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    // Add DbSets
    
    public JourneyLogContext() : base()
    {
    }

    public JourneyLogContext(DbContextOptions<JourneyLogContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Add Fluent configurations
    }
}