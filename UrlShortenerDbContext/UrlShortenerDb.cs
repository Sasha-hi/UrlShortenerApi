using Microsoft.EntityFrameworkCore;

namespace UrlShortenerDbContext;

public class UrlShortenerDb : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlShortenerDb).Assembly);
    }
}