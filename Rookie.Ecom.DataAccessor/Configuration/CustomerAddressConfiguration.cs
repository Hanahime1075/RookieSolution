using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Configuration
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddress");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.CustomerAddresses).HasForeignKey(x => x.CustomerId);
        }
    }
}
