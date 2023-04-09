using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL;

public class JourneyLogContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<TravelLogPlace> TravelLogPlaces { get; set; }
    public DbSet<TravelLog> TravelLogs { get; set; }
    public DbSet<TravelNote> TravelNotes { get; set; }
    public DbSet<NotePhoto> NotePhotos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPlace> UserPlaces { get; set; }
    
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