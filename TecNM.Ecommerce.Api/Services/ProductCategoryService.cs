using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ProductCategoryDTO> SaveAsync(ProductCategoryDTO categoryDto)
    {
        var category = new ProductCategory()
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        category = await _productCategoryRepository.SaveAsync(category);
        categoryDto.Id = category.Id;

        return categoryDto;
    }

    public async Task<ProductCategoryDTO> UpdateAsync(ProductCategoryDTO categoryDto)
    {
        var category = await _productCategoryRepository.GetById(categoryDto.Id);

        if (category == null)
        {
            throw new Exception("Product Category Not Found");
        }

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdatedDate = DateTime.Now;

        await _productCategoryRepository.UpdateAsync(category);
        
        return categoryDto;
    }

    public async Task<List<ProductCategoryDTO>> GetAllAsync()
    {
        var categories = await _productCategoryRepository.GetAllAsync();
        var categoriesDto = categories.Select(c => new ProductCategoryDTO(c)).ToList();
        return categoriesDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);

        return (category != null);
    }

    public async Task<ProductCategoryDTO> GetById(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        if (category == null)
        {
            throw new Exception("Product Category Not Found");
        }

        var categoryDto = new ProductCategoryDTO(category);

        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productCategoryRepository.DeleteAsync(id);
    }
}