using Core.Abstracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IWriteRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
    }
}
