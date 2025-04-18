﻿using Core.Entities.Read;
using Core.Entities.Write;
using Infrastructure.Abstracts;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReadDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("ReadDb")));

            services.AddDbContext<WriteDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("WriteDb")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));


            return services;
        }
    }
}
