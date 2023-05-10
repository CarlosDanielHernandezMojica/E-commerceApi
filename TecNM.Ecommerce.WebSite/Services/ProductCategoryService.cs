using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TecNM.Ecommerce.Core.DTO;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebSite.Services.Interfaces;

namespace TecNM.Ecommerce.WebSite.Services;

public class ProductCategoryService: IProductCategoryService
{
    private readonly string _baseUrl = "http://localhost:7288/";
    private readonly string _endPoint = "api/ProductCategories";

    public ProductCategoryService()
    {
    }

    public async Task<Response<List<ProductCategoryDTO>>> GetAllAsync()
    {
        var url = $"{_baseUrl}{_endPoint}";
        
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<ProductCategoryDTO>>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDTO>> GetById(int id)
    {
        var url = $"{_baseUrl}{_endPoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDTO>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDTO>> SaveAsync(ProductCategoryDTO productCategory)
    {
        var url = $"{_baseUrl}{_endPoint}";

        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDTO>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDTO>> UpdateAsync(ProductCategoryDTO productCategory)
    {
        var url = $"{_baseUrl}{_endPoint}";

        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDTO>>(json);

        return response;
        
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseUrl}{_endPoint}/{id}";

        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }
}