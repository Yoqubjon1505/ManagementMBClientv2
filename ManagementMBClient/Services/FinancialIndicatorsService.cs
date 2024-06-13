using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagementMBClient.DTOs;

public class FinancialIndicatorsService
{
    private readonly HttpClient _httpClient;

    public FinancialIndicatorsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task<List<FinancialIndicatorDTO>> GetByDateAsync(DateTime fromDate, DateTime toDate)
    //{
    //    var response = await _httpClient.PostAsJsonAsync($"api/FinancialIndicators?fromDate={fromDate.ToString("yyyy-MM-dd")}&toDate={toDate.ToString("yyyy-MM-dd")}", new { });
    //    return await response.Content.ReadFromJsonAsync<List<FinancialIndicatorDTO>>();
    //}

    public async Task<FinancialIndicatorDTO> GetByDateAsync(DateTime fromDate, DateTime toDate)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/FinancialIndicators",fromDate);
        if (response.IsSuccessStatusCode)
        {
        return await response.Content.ReadFromJsonAsync<FinancialIndicatorDTO>();

        }
      return  null;
    }

    public async Task<bool> DeleteFinancialIndicatorAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/FinancialIndicators?id={id}");
        return response.IsSuccessStatusCode;
    }
}
