using Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Read
{
    public class OrderItemRead : BaseEntity
    {

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
