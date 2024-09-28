using Microsoft.EntityFrameworkCore;

namespace Tut.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
    }


}
