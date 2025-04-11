using Core.Abstracts;

namespace Core.Entities.Read
{
    public class ProductRead : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public List<ProductImagesRead> Images { get; set; } = [];
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
    }
}
