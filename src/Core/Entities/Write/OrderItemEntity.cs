using Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Write
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
