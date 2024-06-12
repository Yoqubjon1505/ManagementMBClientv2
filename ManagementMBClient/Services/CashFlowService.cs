// Services/CashFlowService.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CashFlowService
{
    private readonly HttpClient _httpClient;

    public CashFlowService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CashFlowDTO>> GetCashFlowsByDateAsync(DateTime fromDate, DateTime toDate)
    {
        var response = await _httpClient.PostAsJsonAsync("api/CashFlow/GetByData", new { fromDate, toDate });
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<CashFlowDTO>>();
        }
        return null;
    }
}
