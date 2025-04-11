using Core.Abstracts;

namespace Core.Entities.Write
{
    public class CategoryEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public IEnumerable<SubCategoryEntity> SubCategories { get; set; } = [];

    }
}
