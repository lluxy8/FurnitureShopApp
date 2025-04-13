using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Data.Factories
{
    public class ReadDbContextFactory : IDesignTimeDbContextFactory<ReadDbContext>
    {
        public ReadDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ReadDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ReadDb"));

            return new ReadDbContext(optionsBuilder.Options);
        }
    }
}
