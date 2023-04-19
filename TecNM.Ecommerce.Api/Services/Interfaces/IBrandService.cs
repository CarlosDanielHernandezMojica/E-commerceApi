using TecNM.Ecommerce.Core.DTO;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    //Save categories method
    Task<BrandDTO>SaveAsync(BrandDTO brand);
    
    //Update product categories method
    Task<BrandDTO>UpdateAsync(BrandDTO brand);
    
    //Return brand list method
    Task<List<BrandDTO>>GetAllAsync();
    
    //Return the id of the brand that will be deleted method
    Task<bool>BrandExist(int id);
    
    Task<bool>DeleteAsync(int id);
    
    //Get brand by id method
    Task<BrandDTO>GetById(int id);
    
    
}