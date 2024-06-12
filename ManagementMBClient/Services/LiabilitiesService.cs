using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagementMBClient.DTOs;

public class LiabilitiesService
{
    private readonly HttpClient _httpClient;

    public LiabilitiesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LiabilitiiesDTO>> GetAllLiabilitiesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<LiabilitiiesDTO>>("api/Liabilitiies");
    }

    public async Task<LiabilitiiesDTO> GetLiabilityByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<LiabilitiiesDTO>($"api/Liabilitiies/GetById?id={id}");
    }

    public async Task<LiabilitiiesDTO> CreateLiabilityAsync(LiabilitiiesDTO liability)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Liabilitiies", liability);
        return await response.Content.ReadFromJsonAsync<LiabilitiiesDTO>();
    }

    public async Task<bool> UpdateLiabilityAsync(Guid id, LiabilitiiesDTO liability)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Liabilitiies/Update?id={id}", liability);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteLiabilityAsync(Guid id)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "api/Liabilitiies/Delete")
        {
            Content = JsonContent.Create(id)
        };
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }
}
