using Microsoft.EntityFrameworkCore;
using Tut.Models;

namespace Tut.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    // Mapping
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<School>()
                    .HasKey(s => s.Id);

        modelBuilder.Entity<School>()
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(150);

        modelBuilder.Entity<School>()
                    .Property(s => s.Capacity)
                    .HasColumnType("int")
                    .IsRequired()
                    .HasDefaultValue(0)
                    .HasAnnotation("MinValue", 0)
                    .HasAnnotation("MaxValue", 200);
    }
}
