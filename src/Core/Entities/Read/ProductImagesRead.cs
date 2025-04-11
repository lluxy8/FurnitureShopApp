using Core.Abstracts;

namespace Core.Entities.Read
{
    public class ProductImagesRead : BaseEntity
    {
        public required string ImageUrl { get; set; }
    }
}
