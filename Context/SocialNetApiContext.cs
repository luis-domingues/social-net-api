using Microsoft.EntityFrameworkCore;
using SocialNetApi.Entities;

namespace SocialNetApi.Context;

public class SocialNetApiContext : DbContext
{
    public SocialNetApiContext(DbContextOptions<SocialNetApiContext> options) : base(options) {  }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);  // Evitar exclusão em cascata

        modelBuilder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.NoAction);  // Evitar exclusão em cascata
    }
}