using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL;

public class JourneyLogContext : DbContext
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