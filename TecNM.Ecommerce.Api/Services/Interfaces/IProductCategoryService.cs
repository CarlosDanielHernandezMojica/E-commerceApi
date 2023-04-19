using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IProductCategoryService
{
    //Save categories method
    Task<ProductCategoryDTO>SaveAsync(ProductCategoryDTO category);
    
    //Update product categories method
    Task<ProductCategoryDTO>UpdateAsync(ProductCategoryDTO category);
    
    //Return category list method
    Task<List<ProductCategoryDTO>>GetAllAsync();
    
    //Return the id of the category that will be deleted method
    Task<bool>ProductCategoryExist(int id);
    
    Task<bool>DeleteAsync(int id);
    
    //Get category by id method
    Task<ProductCategoryDTO>GetById(int id);
}