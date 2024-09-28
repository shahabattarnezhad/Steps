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
}
