using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders
{

    public class PurchaseOrderService
    {
        public PurchaseOrderService(IJSRuntime js,
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

        public async Task<GetAllPurchaseOrderOutputModel> GetAllPurchaseOrder(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/GetAll?";
            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (sorting != null)
                url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
            if (skipCount != null)
                url += "SkipCount=" + HttpUtility.UrlEncode("" + skipCount) + "&";
            if (maxResultCount != null)
                url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount) + "&";
            url = url.Replace("/[?&]$/", "");


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllPurchaseOrderOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllPurchaseOrderOutputModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Accountability Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }

            return result;
        }

        public async Task CreatePurchaseOrder(PurchaseOrderModel purchaseOrderModel)
        {
            CreatePurchaseOrderModel input = new()
            {
                Number = purchaseOrderModel.Number,
                CompanyId = purchaseOrderModel.CompanyId,
                PurchaseOrderTypeId = (int)purchaseOrderModel.PurchaseOrderTypeId,
                Document = purchaseOrderModel.Document,
                Price = purchaseOrderModel.Price,
                IssuedDate = purchaseOrderModel.IssuedDate,
                ShippingInvoice = purchaseOrderModel.ShippingInvoice,
                ETD = purchaseOrderModel.ETD,
                ETA = purchaseOrderModel.ETA,
                PackingList = purchaseOrderModel.PackingList,
                Blawb = purchaseOrderModel.Blawb,
                FabricInspectionReport = purchaseOrderModel.FabricInspectionReport,
                FabricTestingReport = purchaseOrderModel.FabricTestingReport,
                RequestId = purchaseOrderModel.RequestId
            };

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Add Success!", "", $"/inventory/purchaseorder");
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Add Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }

        public async Task<PurchaseOrderModel> GetPurchaseOrder(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/Get?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetPurchaseOrderModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetPurchaseOrderModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }
            return result.Result;
        }
        public async Task UpdatePurchaseOrder(PurchaseOrderModel purchaseOrderModel)
        {
            UpdatePurchaseOrderModel input = new()
            {
                Id = purchaseOrderModel.Id,
                CompanyId = purchaseOrderModel.CompanyId,
                PurchaseOrderTypeId = (int)purchaseOrderModel.PurchaseOrderTypeId,
                Number = purchaseOrderModel.Number,
                Document = purchaseOrderModel.Document,
                Price = purchaseOrderModel.Price,
                IssuedDate = purchaseOrderModel.IssuedDate,
                ShippingInvoice = purchaseOrderModel.ShippingInvoice,
                ETD = purchaseOrderModel.ETD,
                ETA = purchaseOrderModel.ETA,
                PackingList = purchaseOrderModel.PackingList,
                Blawb = purchaseOrderModel.Blawb,
                FabricInspectionReport = purchaseOrderModel.FabricInspectionReport,
                FabricTestingReport = purchaseOrderModel.FabricTestingReport,
                RequestId = purchaseOrderModel.RequestId
            };

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/Update";

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<UpdateReservationColorOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/purchaseorder/detail/{input.Id}");
                //await GetReservationColor(data.Result.Value);
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Update Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }
        public async Task DeletePurchaseOrder(Guid id)
        {
            DeletePurchaseOrderModel input = new() { Id = id };

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/Delete?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
                await GetAllPurchaseOrder(null, null, null, 100);
                //var data = await JsonSerializer.DeserializeAsync<GetReservationMaterialTypeOutputModel>(responseStream);
                //result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }
        public async Task<List<PurchaseOrderWithRollsModel>> GetRollsWithPurchaseOrder(string input)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/GetRollsWithPurchaseOrder?ids=" + input;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            PurchaseOrderWithRollsModelResults result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<PurchaseOrderWithRollsModelResults>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }
            return result.Result;
        }

        public async Task<List<PurchaseOrderISTModel>> GetPurchaseOrderIST(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/GetIplexPurchaseOrder?id=" + id;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            PurchaseOrderISTModelResults result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<PurchaseOrderISTModelResults>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }
            return result.Result;
        }

        public async Task<PurchaseOrderWithSubMaterialsModel> GetSubMaterialWithPurchaseOrder(string input)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/GetSubMaterialsWithPurchaseOrder?ids=" + input;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            PurchaseOrderWithSubMaterialsModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<PurchaseOrderWithSubMaterialsModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }
            return result;
        }

        public async Task ReceivedPurchaseOrder(ReceivedPurchaseOrderModel input)
        {

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchaseOrder/ReceivedPurchaseOrder";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Add Success!", "", $"/inventory/purchaseorder");
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Add Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }

    }
}

