﻿using Core.Entities.Read;
using Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ReadDbContext : AppDbContextBase<ReadDbContext>
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

        public DbSet<AdminRead> Admins { get; set; }
        public DbSet<CategoryRead> Categories { get; set; }
        public DbSet<CustomerRead> Customers { get; set; }
        public DbSet<OrderRead> Orders { get; set; }
        public DbSet<OrderItemRead> OrderItems { get; set; }
        public DbSet<ProductRead> Products { get; set; }
        public DbSet<ProductImagesRead> ProductImages { get; set; }
        public DbSet<SubCategoryRead> SubCategories { get; set; }

    }
}
