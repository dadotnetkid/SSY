//NOTE DITO LALAGAY ANG LOGIC SA BACKEND(API CALLS)

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease
{

    public class RevenueReleaseService
    {
        public RevenueReleaseService(IJSRuntime js,
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

        public async Task<CollectionReviewListModel> GetAllCollection()
        {
            // var url = $"{_configuration["App:ServerRootAddress"]}/Accountability/Get?Id={id}";

            // var request = new HttpRequestMessage(HttpMethod.Get, url);
            // request.Headers.Add("Accept", "*/* ");
            // request.Headers.Add("User-Agent", "Inventory");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            CollectionReviewListModel result = new();

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
            result.CollectionReview.Add(new CollectionReviewModel()
            {
                CollectionName = "test",
                LaunchDate = "test",
                TotalSales = 2.12,
                Refunds = 3.14,
                NetSales = 123,
                Revenue = 1412
            });
            result.CollectionReview.Add(new CollectionReviewModel()
            {
                CollectionName = "test",
                LaunchDate = "test",
                TotalSales = 22.12,
                Refunds = 341.14,
                NetSales = 14223,
                Revenue = 1442412
            });
            return result;
        }
        public async Task<TransactionListModel> GetAllTransaction()
        {

            TransactionListModel result = new();

            result.Transaction.Add(new TransactionModel()
            {
                Date = "test",
                Amount = "test",
                Type = "asgas",
                Notes = "qwgq",
                Balance = 123
            });
            result.Transaction.Add(new TransactionModel()
            {
                Date = "test123",
                Amount = "test4124",
                Type = "asgfqwas",
                Notes = "qwqwfgq",
                Balance = 17223
            });
            return result;
        }
        public async Task<RevenueReleaseModel> GetRevenueRelease()
        {

            RevenueReleaseModel result = new();

            result.TotalSales = 1241241;
            result.YourRevenue = 15125125;
            result.TotalRevenueReleased = 1241125;
            result.TotalAvailableForRelease = 125125;
            result.RevenuePendingRelease = 1241251;
            return result;
        }
    }

}


