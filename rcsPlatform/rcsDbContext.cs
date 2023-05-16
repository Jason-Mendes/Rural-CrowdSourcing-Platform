using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class rcsDbContext : IdentityDbContext
{
    public rcsDbContext(DbContextOptions<rcsDbContext> options)
        : base(options)
    { }

    // Define your DbSets here. For example:
    // public DbSet<YourEntity> YourEntities { get; set; }
}
