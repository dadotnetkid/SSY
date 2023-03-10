using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories
{
    public class PurchasingHistoryService
    {
        public PurchasingHistoryService(IJSRuntime js,
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

        public async Task<GetAllPurchasingHistoryOutputModel> GetAllPurchasingHistory(Guid materialId)
        {
            GetAllPurchasingHistoryOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchasingHistory/GetAll?MaxResultCount=100&MaterialId={materialId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllPurchasingHistoryOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Purchasing History Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetPurchasingHistoryOutputModel> GetPurchasingHistory(Guid id)
        {
            GetPurchasingHistoryOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/PurchasingHistory/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetPurchasingHistoryOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Purchasing History Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task CreateMaterialPurchasingHistory(CreatePurchasingHistoryModel purchasingHistory)
        {
            var json = JsonSerializer.Serialize(purchasingHistory);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/PurchasingHistoryCreate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                await GetPurchasingHistory(data.Result.Value);
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

        public async Task UpdateMaterialPurchasingHistory(UpdatePurchasingHistoryModel purchasingHistory)
        {
            var json = JsonSerializer.Serialize(purchasingHistory);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/PurchasingHistoryUpdate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
                await GetPurchasingHistory(data.Result.Value);
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

        public async Task DeleteMaterialPurchasingHistory(Guid id)
        {
            DeletePurchasingHistoryModel transaction = new() { Id = id };

            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/PurchasingHistoryDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
                await GetPurchasingHistory(data.Result.Value);
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }

        }

        public async Task CreateSubMaterialPurchasingHistory(CreatePurchasingHistoryModel purchasingHistory)
        {
            var json = JsonSerializer.Serialize(purchasingHistory);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/PurchasingHistoryCreate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                await GetPurchasingHistory(data.Result.Value);
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

        public async Task UpdateSubMaterialPurchasingHistory(UpdatePurchasingHistoryModel purchasingHistory)
        {
            var json = JsonSerializer.Serialize(purchasingHistory);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/PurchasingHistoryUpdate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
                await GetPurchasingHistory(data.Result.Value);
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

        public async Task DeleteSubMaterialPurchasingHistory(Guid id)
        {
            DeletePurchasingHistoryModel transaction = new() { Id = id };

            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/PurchasingHistoryDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CrudPurchasingHistoryOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
                await GetPurchasingHistory(data.Result.Value);
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }

        }

    }
}

