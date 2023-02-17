using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class BackendContext : DbContext
{
    public DbSet<Role>? Role { get; set; }
    public DbSet<User>? User { get; set; }
    public DbSet<UserRole>? UserRole { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"User ID=postgres;Password=Aa123456;Server=127.0.0.1;Port=5432;Database=postgres;Integrated Security=true;Pooling=true;ApplicationName=LAYERED_ARCHITECTURE");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}