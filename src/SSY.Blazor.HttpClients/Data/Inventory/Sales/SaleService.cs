//NOTE DITO LALAGAY ANG LOGIC SA BACKEND(API CALLS)

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Sales.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Sales
{

    public class SaleService
    {
        public SaleService(IJSRuntime js,
        IHttpClientFactory ClientFactory,
        NavigationManager NavigationManager,
        IConfiguration Configuration)
        {
            _js = js;
            _clientFactory = ClientFactory;
            _navigationManager = NavigationManager;
            _configuration = Configuration;
        }

        #region Injects

        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;

        #endregion

        public async Task<SaleListModel> GetAllSales()
        {
            // var url = $"{_configuration["App:ServerRootAddress"]}/Accountability/Get?Id={id}";

            // var request = new HttpRequestMessage(HttpMethod.Get, url);
            // request.Headers.Add("Accept", "*/* ");
            // request.Headers.Add("User-Agent", "Inventory");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            SaleListModel result = new();

            // if (response.IsSuccessStatusCode)
            // {
            //     using var responseStream = await response.Content.ReadAsStreamAsync();

            //     var data = await JsonSerializer.DeserializeAsync<BankDetailModel>(responseStream);
            //     result = data;
            // }
            // else
            // {
            //     //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Accountability Failed!", "");
            //     System.Console.WriteLine(response.Content.ToString());
            // }
            result.Sales.Add(new SaleModel()
            {
                ProductName = "test",
                ProductType = "test",
                Orders = 2.12,
                NetItems = 3.14,
                Sales = 123,
                SalesReturn = 1412
            });
            result.Sales.Add(new SaleModel()
            {
                ProductName = "qwe",
                ProductType = "rqw",
                Orders = 2.12,
                NetItems = 13.24,
                Sales = 12341,
                SalesReturn = 124412
            });
            return result;
        }

    }
}

