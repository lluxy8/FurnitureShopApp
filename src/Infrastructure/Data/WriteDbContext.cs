using Core.Entities.Write;
using Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class WriteDbContext : AppDbContextBase
    {
        public WriteDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductImagesEntity> ProductImages { get; set; }
        public DbSet<SubCategoryEntity> SubCategories { get; set; }


    }
}
