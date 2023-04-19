using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.DTO;

public class ProductCategoryDTO: DTOBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ProductCategoryDTO()
    {
        
    }

    public ProductCategoryDTO(ProductCategory category)
    {
        Id = category.Id;
        Name = category.Name;
        Description = category.Description;
    }
}