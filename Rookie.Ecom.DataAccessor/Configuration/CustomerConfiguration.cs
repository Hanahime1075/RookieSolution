using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(200);

            builder.Property(x => x.LastName).HasMaxLength(200);

            builder.Property(x => x.Img);

            builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.UserId);
        }
    }
}
