using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace rcsPlatform.Models
{
public class Comment
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ModelId { get; set; }

    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string Text { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class rcsDbContext : IdentityDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public rcsDbContext(DbContextOptions<rcsDbContext> options)
        : base(options)
    { }
    
    // Define your DbSets here. For example:
    // public DbSet<YourEntity> YourEntities { get; set; }
}
}