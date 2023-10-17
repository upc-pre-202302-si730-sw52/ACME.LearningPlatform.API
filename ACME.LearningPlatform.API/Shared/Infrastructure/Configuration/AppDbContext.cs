using Microsoft.EntityFrameworkCore;

namespace ACME.LearningPlatform.API.Shared.Infrastructure.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
    }
}