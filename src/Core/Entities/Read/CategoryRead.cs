using Core.Abstracts;

namespace Core.Entities.Read
{
    public class CategoryRead : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public List<SubCategoryRead> SubCategories { get; set; } = [];
    }
}
