using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ManagementMBClient.Services
{
    public class CashFlowService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CashFlowService> _logger;

        public CashFlowService(HttpClient httpClient, ILogger<CashFlowService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CashFlowDto> GetCashFlowByDateAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var url = $"api/CashFlow/GetByDate?fromDate={fromDate:O}&toDate={toDate:O}";
                _logger.LogInformation($"Request URL: {url}");
                var response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CashFlowDto>();
                    _logger.LogInformation($"Response Data: {result}");
                    return result;
                }
                else
                {
                    _logger.LogWarning($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting cash flow data.");
            }

            return null;
        }
    }
}
