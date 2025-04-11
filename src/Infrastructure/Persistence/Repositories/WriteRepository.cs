using Core.Abstracts;
using Infrastructure.Abstracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class WriteRepository<T> : RepositoryBase<WriteDbContext, T> 
        where T : BaseEntity
    {
        public WriteRepository(WriteDbContext context) : base(context)
        {
        }
    }

}
