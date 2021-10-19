using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(200);

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.ProductImg).IsRequired();

            builder.Property(x => x.PublisherName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.AuthorName).HasMaxLength(50).IsRequired();
        }
    }
}
