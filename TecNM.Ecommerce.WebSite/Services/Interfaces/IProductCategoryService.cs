using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDTO>>> GetAllAsync();

    Task<Response<ProductCategoryDTO>> GetById(int id);

    Task<Response<ProductCategoryDTO>> SaveAsync(ProductCategoryDTO productCategory);
    
    Task<Response<ProductCategoryDTO>> UpdateAsync(ProductCategoryDTO productCategory);

    Task<Response<bool>> DeleteAsync(int id);

}