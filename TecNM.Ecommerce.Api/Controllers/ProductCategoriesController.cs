using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDTO>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDTO>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDTO>>> Post([FromBody] ProductCategoryDTO categoryDTO)
    {
        var response = new Response<ProductCategoryDTO>()
        {
            Data = await _productCategoryService.SaveAsync(categoryDTO)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDTO>>> GetById(int id)
    {
        var response = new Response<ProductCategoryDTO>();
        
        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product category not found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.GetById(id);
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ProductCategoryDTO>>> Update([FromBody] ProductCategoryDTO categoryDTO)
    {

        var response = new Response<ProductCategoryDTO>();
        
        if (!await _productCategoryService.ProductCategoryExist(categoryDTO.Id))
        {
            response.Errors.Add("Product category not found");
            return NotFound(response);
        }
        
        response.Data = await _productCategoryService.UpdateAsync(categoryDTO);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }

}