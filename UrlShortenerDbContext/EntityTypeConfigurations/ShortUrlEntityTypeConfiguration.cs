using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortenerDbContext.Entities;

namespace UrlShortenerDbContext.EntityTypeConfigurations;

public class ShortUrlEntityTypeConfiguration : IEntityTypeConfiguration<ShortUrl>
{
    public void Configure(EntityTypeBuilder<ShortUrl> builder)
    {
        builder.HasKey(x => x.Id);
    }
}