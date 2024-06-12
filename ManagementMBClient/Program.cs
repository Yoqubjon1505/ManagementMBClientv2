
using Blazorise;
using ManagementMBClient.Pages.ExpensesPage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Syncfusion.Blazor;


namespace ManagementMBClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5266/") });
            builder.Services.AddScoped<ExpensesService>();
            builder.Services.AddScoped<LiabilitiesService>();
            builder.Services.AddScoped<FinancialIndicatorsService>();
            builder.Services.AddScoped<BalanceService>();
            builder.Services.AddScoped<PurchaseService>();
            builder.Services.AddScoped<CashFlowService>();
            //added
            builder.Services.AddBlazorise();
            //added for design
            builder.Services.AddSyncfusionBlazor();

            //added for MudBlazor
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
