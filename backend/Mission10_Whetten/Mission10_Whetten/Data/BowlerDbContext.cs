using Microsoft.EntityFrameworkCore;

namespace Mission10_Whetten.Data;

// Set up liason between the database and the data classes
public class BowlerDbContext : DbContext
{
    public BowlerDbContext(DbContextOptions<BowlerDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>()
        .HasOne(b => b.Team)
        .WithMany()
        .HasForeignKey(b => b.TeamID);
    }
}