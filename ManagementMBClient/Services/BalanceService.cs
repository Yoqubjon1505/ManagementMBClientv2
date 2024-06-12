using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagementMBClient.DTOs;

public class BalanceService
{
    private readonly HttpClient _httpClient;

    public BalanceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BalanceDto> GetBalanceByDateAsync(DateTime date)
    {
        var response = await _httpClient.PostAsJsonAsync("api/balance", date);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BalanceDto>();
        }
        return null;
    }

    public async Task<IEnumerable<BalanceDto>> GetAllBalancesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<BalanceDto>>("api/balance");
    }

    public async Task<bool> DeleteBalanceAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/balance/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteBalancesAsync(IEnumerable<Guid> ids)
    {
        var response = await _httpClient.PostAsJsonAsync("api/balance/delete-multiple", ids);
        return response.IsSuccessStatusCode;
    }
}
