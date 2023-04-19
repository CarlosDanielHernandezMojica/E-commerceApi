using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.DTO;

public class BrandDTO: DTOBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public BrandDTO()
    {
        
    }

    public BrandDTO(Brand brand)
    {
        Id = brand.Id;
        Name = brand.Name;
        Description = brand.Description;
    }
}