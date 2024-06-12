using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ManagementMBClient.DTOs;


public class ExpensesService
{
    private readonly HttpClient _httpClient;

    public ExpensesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Expenses>> GetAllExpensesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Expenses>>("api/Expenses/GetAll");
    }

    public async Task<Expenses> GetExpenseByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Expenses>($"api/Expenses/GetById?id={id}");
    }

    public async Task<Expenses> CreateExpenseAsync(Expenses expense)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Expenses", expense);
        return await response.Content.ReadFromJsonAsync<Expenses>();
    }

    public async Task<bool> UpdateExpenseAsync(Guid id, Expenses expense)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Expenses?id={id}", expense);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteExpenseAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/Expenses?id={id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Expenses>> GetExpensesByCategoryAsync(ExpenseCategory category)
    {
        return await _httpClient.GetFromJsonAsync<List<Expenses>>($"api/Expenses/GetByCategory?category={category}");
    }

    public async Task<List<Expenses>> GetExpensesByDateAsync(DateTime date)
    {
        return await _httpClient.GetFromJsonAsync<List<Expenses>>($"api/Expenses/GetDataTime?dateTime={date.ToString("yyyy-MM-dd")}");
    }
}
