﻿using Core.Abstracts;

namespace Core.Entities.Write
{
    public class ProductEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string UrlName { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public IEnumerable<ProductImagesEntity> Images { get; set; } = [];
        public Guid CategoryId { get; set; }
        public SubCategoryEntity Category { get; set; } = null!;
    }
}
