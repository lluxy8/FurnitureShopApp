using Core.Common.Values;
using Core.Entities.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                   .IsRequired()
                   .HasMaxLength(DbMaxLengthValues.Name);

            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(DbMaxLengthValues.Name);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(DbMaxLengthValues.Email);
        }
    }
}
