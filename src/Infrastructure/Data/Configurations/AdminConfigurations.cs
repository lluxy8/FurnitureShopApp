using Core.Common.Constants;
using Core.Entities.Write;
using Core.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configurations
{
    public class AdminConfigurations : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(DbMaxLengthValues.Name);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(DbMaxLengthValues.Password);


        }
    }
}
