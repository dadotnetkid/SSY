using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.Transactions.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Transactions
{
    public class TransactionService
    {
        public TransactionService(IJSRuntime js,
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

        public async Task<GetAllTransactionOutputModel> GetAllTransaction(Guid materialId)
        {
            GetAllTransactionOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/Transaction/GetAll?MaxResultCount=100&MaterialId={materialId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllTransactionOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Reservation Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetTransactionOutputModel> GetTransaction(Guid id)
        {
            GetTransactionOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/Transaction/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetTransactionOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Reservation Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task CreateMaterialTransaction(CreateTransactionModel transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/TransactionCreate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                await GetTransaction(data.Result.Value);
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

        public async Task UpdateMaterialTransaction(UpdateTransactionModel transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/TransactionUpdate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
                await GetTransaction(data.Result.Value);
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

        public async Task DeleteMaterialTransaction(Guid id)
        {
            DeleteTransactionModel transaction = new() { Id = id };

            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/TransactionDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
                await GetTransaction(data.Result.Value);
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

        public async Task CreateSubMaterialTransaction(CreateTransactionModel transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/TransactionCreate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                await GetTransaction(data.Result.Value);
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

        public async Task UpdateSubMaterialTransaction(UpdateTransactionModel transaction)
        {
            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/TransactionUpdate";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
                await GetTransaction(data.Result.Value);
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

        public async Task DeleteSubMaterialTransaction(Guid id)
        {
            DeleteTransactionModel transaction = new() { Id = id };

            var json = JsonSerializer.Serialize(transaction);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/TransactionDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOrUpdateTransactionOutputModel>(responseStream);
                Console.WriteLine(JsonSerializer.Serialize(data));
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
                await GetTransaction(data.Result.Value);
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

