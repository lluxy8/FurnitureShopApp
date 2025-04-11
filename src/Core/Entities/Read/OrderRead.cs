using Core.Abstracts;

namespace Core.Entities.Read
{
    public class OrderRead : BaseEntity
    {

        public Guid CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItemRead> Items { get; set; } = [];
    }
}
