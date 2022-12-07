using Microsoft.EntityFrameworkCore;

namespace weather.API.DataBase;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.Property(b => b.Temperature).HasPrecision(10, 5);
            entity.Property(b => b.Humidity).HasPrecision(10, 5);
        });
            
        modelBuilder.Entity<HistMeasure>(entity =>
        {
            entity.Property(b => b.MaxTemperature).HasPrecision(10, 5);
            entity.Property(b => b.MinTemperature).HasPrecision(10, 5);
            entity.Property(b => b.MaxHumidity).HasPrecision(10, 5);
            entity.Property(b => b.MinHumidity).HasPrecision(10, 5);
        });
    }

    public DbSet<Measure>? Measures { get; set; }
    public DbSet<HistMeasure>? HistMeasures { get; set; }
}
