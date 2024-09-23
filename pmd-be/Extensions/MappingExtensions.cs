using pmd_be.Dto;
using pmd_be.Models;

namespace pmd_be.Extensions
{
    public static class MappingExtensions
    {
        //not using automapper as I believe its an antipattern that can hide translations very well in large projects
        public static ProductViewDto ToProductView(this Product product)
        {
            return new ProductViewDto
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                Price = product.Price,
                SKU = product.SKU,
                StockQuantity = product.StockQuantity,
                DateAdded = product.DateAdded,
                Category = ((Category)product.Category).ToString()
            };
        }

        public static Product ToProduct(this ProductCreateDto productCreateDto) 
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = productCreateDto.Name,
                Code = productCreateDto.Code,
                Price = productCreateDto.Price,
                SKU = productCreateDto.SKU,
                StockQuantity = productCreateDto.StockQuantity,
                DateAdded = DateTimeOffset.UtcNow,
                Category =  productCreateDto.Category
            };
        }
    }
}
