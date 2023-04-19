using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    //Save categories method
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //Update product categories method
    Task<ProductCategory> UpdateAsync(ProductCategory category);
    
    //Return category list method
    Task<List<ProductCategory>> GetAllAsync();
    
    //Return the id of the category that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get category by id method
    Task<ProductCategory> GetById(int id);
}

