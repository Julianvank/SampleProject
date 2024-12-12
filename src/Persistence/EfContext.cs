using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class EfContext : DbContext
{
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Indice> Indices => Set<Indice>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;port=4310;database=MigrationsTestProject;user=root;password=root",
            new MariaDbServerVersion("11.3.2-jammy"), options => options.EnableRetryOnFailure());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>().HasKey(id => id.Id);
        modelBuilder.Entity<Stock>().Property(id => id.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Indice>().HasKey(id => id.Id);
        modelBuilder.Entity<Indice>().Property(id => id.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Indice>().HasMany(d => d.Stocks);
    }

    public IQueryable<T> GetToDoSet<T>() where T : class
    {
        return Set<T>();
    }
}