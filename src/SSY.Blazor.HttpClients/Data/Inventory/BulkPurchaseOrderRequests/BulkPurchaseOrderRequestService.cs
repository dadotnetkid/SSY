using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model;
using SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Dto;
using SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Model;


namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests
{
    public class BulkPurchaseOrderRequestService
    {
        public BulkPurchaseOrderRequestService(IJSRuntime js,
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

        public async Task<GetAllBulkPurchaseOrderRequestModel> GetAllBulkPurchaseOrderRequest(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/GetAll?";

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

            GetAllBulkPurchaseOrderRequestModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllBulkPurchaseOrderRequestModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }

            return result;
        }

        public async Task<GetBulkPurchaseOrderRequestModel> GetBulkPurchaseOrderRequest(Guid id)
        {
            GetBulkPurchaseOrderRequestModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetBulkPurchaseOrderRequestModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get ReservationColor Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<CreateBulkPurchaseOrderRequestOutputModel> CreateBulkPurchaseOrderRequest(CreateBulkPurchaseOrderRequestDto input)
        {
            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            CreateBulkPurchaseOrderRequestOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateBulkPurchaseOrderRequestOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "success", "Bulk Purchase Order Successfully Added!", "");

                result = data;
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Bulk Purchase Order Add Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }

            return result;
        }

        //public async Task CreateBulkPurchaseOrderRequest(CreateBulkPurchaseOrderRequestDto input)
        //{


        //    var json = JsonSerializer.Serialize(input);
        //    System.Console.WriteLine(json);

        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/Create";

        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Headers.Add("Accept", "*/*");
        //    request.Headers.Add("User-Agent", "Inventory");
        //    request.Content = content;

        //    var client = _clientFactory.CreateClient();

        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseStream = await response.Content.ReadAsStreamAsync();
        //        await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Add Success!", "", $"/inventory/BulkPurchaseOrderRequest");
        //    }
        //    else
        //    {
        //        var responseStream = await response.Content.ReadAsStreamAsync();
        //        var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
        //        var error = data.Error;
        //        await _js.InvokeVoidAsync("defaultMessage", "error", "Add Failed!", $"{error.Message}");
        //        Console.WriteLine(JsonSerializer.Serialize(error));
        //    }
        //}

        public async Task UpdateBulkPurchaseOrderRequest(UpdateBulkPurchaseOrderRequestModel input)
        {
            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/Update";

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
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

        public async Task DeleteBulkPurchaseOrderRequest(Guid id)
        {
            DeleteBulkPurchaseOrderRequestModel input = new() { Id = id };

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/Delete?Id={id}";

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
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task CancelRequests(List<Guid> input)
        {
            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/CancelRequests";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Cancel Bulk Purchase Order Request Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }

        public async Task ChangeRequestStatus(ChangeRequestStatusModel input)
        {
            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/BulkPurchaseOrderRequest/ChangeBulkPurchaseOrderRequestStatus";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Change Status Success!", "");
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Assign Bulk Purchase Order Request Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }

    }
}

