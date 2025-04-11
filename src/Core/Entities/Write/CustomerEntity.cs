using Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Write
{
    public class CustomerEntity : BaseEntity
    {

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public ICollection<OrderEntity> Orders { get; set; } = [];
    }
}
