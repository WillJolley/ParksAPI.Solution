using Microsoft.EntityFrameworkCore;

namespace ParksAPI.Models
{
  public class ParksAPIContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParksAPIContext(DbContextOptions<ParksAPIContext> options) : base(options)
    {
    }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Olympic National Park", State = "Washington", Features = "Lake Crescent, Hoh River"},
          new Park { ParkId = 2, Name = "Beacon Rock State Park", State = "Washington", Features = "Beacon Rock, Hardy Ridge Trail" },
          new Park { ParkId = 3, Name = "Zion National Park", State = "Utah", Features = "Angels Landing, Weeping Rock"}
        );
      }
    }
  }