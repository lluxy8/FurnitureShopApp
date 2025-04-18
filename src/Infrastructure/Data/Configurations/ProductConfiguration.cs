﻿using Core.Common.Constants;
using Core.Entities.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(DbMaxLengthValues.Name);

            builder.Property(p => p.Description)
                   .HasMaxLength(DbMaxLengthValues.Description);

            builder.Property(p => p.UrlName)
                   .HasMaxLength(DbMaxLengthValues.UrlName);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
