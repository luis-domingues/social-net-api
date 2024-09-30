using Microsoft.EntityFrameworkCore;
using SocialNetApi.Entities;

namespace SocialNetApi.Context;

public class SocialNetApiContext : DbContext
{
    public SocialNetApiContext(DbContextOptions<SocialNetApiContext> options) : base(options) {  }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}