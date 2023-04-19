using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController: ControllerBase
{
    private readonly IBrandService _brandService;
    
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<BrandDTO>>>> GetAll()
    {
        var response = new Response<List<BrandDTO>>
        {
            Data = await _brandService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<BrandDTO>>> Post([FromBody] BrandDTO brandDTO)
    {
        var response = new Response<BrandDTO>()
        {
            Data = await _brandService.SaveAsync(brandDTO)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDTO>>> GetById(int id)
    {
        var response = new Response<BrandDTO>();
        
        if (!await _brandService.BrandExist(id))
        {
            response.Errors.Add("Product brand not found");
            return NotFound(response);
        }

        response.Data = await _brandService.GetById(id);
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<BrandDTO>>> Update([FromBody] BrandDTO brandDTO)
    {

        var response = new Response<BrandDTO>();
        
        if (!await _brandService.BrandExist(brandDTO.Id))
        {
            response.Errors.Add("Product brand not found");
            return NotFound(response);
        }
        
        response.Data = await _brandService.UpdateAsync(brandDTO);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _brandService.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }
}