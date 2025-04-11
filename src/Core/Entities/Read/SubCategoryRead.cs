using Core.Abstracts;

namespace Core.Entities.Read
{
    public class SubCategoryRead : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public List<ProductRead> Products { get; set; } = [];
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
