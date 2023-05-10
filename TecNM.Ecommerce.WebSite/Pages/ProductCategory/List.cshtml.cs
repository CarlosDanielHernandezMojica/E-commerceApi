using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.WebSite.Services.Interfaces;

namespace TecNM.Ecommerce.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    private readonly IProductCategoryService _service;
    public List<ProductCategoryDTO> ProductCategories { get; set; }
    
    public ListModel(IProductCategoryService service)
    {
        ProductCategories = new List<ProductCategoryDTO>();
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        // Service call
        var response = await _service.GetAllAsync();
        ProductCategories = response.Data;

        return Page();
    }
}