using Core.Abstracts;

namespace Core.Entities.Write
{
    public class ProductImagesEntity : BaseEntity
    {
        public required string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
    }
}
