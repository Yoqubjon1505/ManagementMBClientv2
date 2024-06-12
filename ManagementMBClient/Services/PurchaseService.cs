// Services/PurchaseService.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagementMBClient.DTOs;

public class PurchaseService
{
    private readonly HttpClient _httpClient;

    public PurchaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetAllPurchasesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/purchase/GetAll");
    }

    public async Task<Product> GetPurchaseByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"api/purchase/GetById?id={id}");
    }

    public async Task<HttpResponseMessage> CreatePurchaseAsync(Guid id, Product productDTO)
    {
        return await _httpClient.PostAsJsonAsync($"api/purchase?id={id}", productDTO);
    }

    public async Task<HttpResponseMessage> UpdatePurchaseAsync(Guid id, Product productDTO)
    {
        return await _httpClient.PutAsJsonAsync($"api/Purchase?id={id}", productDTO);
    }

    public async Task<HttpResponseMessage> DeletePurchaseAsync(Guid id)
    {
        return await _httpClient.DeleteAsync($"api/Purchase?id={id}");
    }
}
