using Core.Abstracts;

namespace Core.Entities.Write
{
    public class OrderEntity : BaseEntity
    {

        public Guid CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItemEntity> OrderItems { get; set; } = [];
    }
}
