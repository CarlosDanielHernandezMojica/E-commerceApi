using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Services;

public class BrandService: IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandDTO> SaveAsync(BrandDTO brandDto)
    {
        var brand = new Brand()
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        brand = await _brandRepository.SaveAsync(brand);
        brandDto.Id = brand.Id;

        return brandDto;
    }

    public async Task<BrandDTO> UpdateAsync(BrandDTO brandDto)
    {
        var brand = await _brandRepository.GetById(brandDto.Id);

        if (brand == null)
        {
            throw new Exception("Product Category Not Found");
        }

        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.UpdatedBy = "";
        brand.UpdatedDate = DateTime.Now;

        await _brandRepository.UpdateAsync(brand);
        
        return brandDto;
    }

    public async Task<List<BrandDTO>> GetAllAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        var brandsDto = brands.Select(c => new BrandDTO(c)).ToList();
        return brandsDto;
    }

    public async Task<bool> BrandExist(int id)
    {
        var brand = await _brandRepository.GetById(id);

        return (brand != null);
    }

    public async Task<BrandDTO> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand == null)
        {
            throw new Exception("Product Category Not Found");
        }

        var brandDto = new BrandDTO(brand);

        return brandDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandRepository.DeleteAsync(id);
    }
}