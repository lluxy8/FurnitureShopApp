using Core.Abstracts;

namespace Core.Entities.Write
{
    public class SubCategoryEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public IEnumerable<ProductEntity> Products { get; set; } = [];
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
    }
}
