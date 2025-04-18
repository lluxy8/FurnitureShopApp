﻿using Core.Abstracts;
using Infrastructure.Abstracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReadRepository<T> : RepositoryBase<ReadDbContext, T>, IReadRepository<T>
        where T : BaseEntity
    {
        public ReadRepository(ReadDbContext context) : base(context) { }
    }

}
