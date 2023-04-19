using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    //Save categories method
    Task<Brand> SaveAsync(Brand category);
    
    //Update product categories method
    Task<Brand> UpdateAsync(Brand category);
    
    //Return category list method
    Task<List<Brand>> GetAllAsync();
    
    //Return the id of the category that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get category by id method
    Task<Brand> GetById(int id);
}