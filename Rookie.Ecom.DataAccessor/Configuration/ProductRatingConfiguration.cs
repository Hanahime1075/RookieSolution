using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Configuration
{
    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.ToTable("ProductRating");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comment).IsRequired();

            builder.Property(x => x.Rating).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductRatings).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.User).WithMany(x => x.ProductRatings).HasForeignKey(x => x.UserId);

        }
    }
}
