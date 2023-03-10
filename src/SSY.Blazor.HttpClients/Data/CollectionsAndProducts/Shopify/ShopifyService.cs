using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify
{

    public class ShopifyService
    {
        public ShopifyService(IJSRuntime js,
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
        public async Task CreateShopify(ShopifyModel input)
        {
            CreateShopifyInputModel createShopifyInputModel = new()
            {
                Name = input.Name,
                Number = input.Number,
                Price = input.Price,
                FabricComposition = input.FabricComposition,
                CareInstruction = input.CareInstruction,
                Tags = input.Tags,
                Description = input.Description
            };

            input.MediaFiles.ForEach(x =>
            {
                createShopifyInputModel.MediaFiles.Add(new() { MediaFileId = x.MediaFile.Id, OrderNumber = x.OrderNumber });
            });

            var json = JsonSerializer.Serialize(createShopifyInputModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/shopify";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

        }

        public async Task<GetAllShopifyOutputModel> GetAllShopify(string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/shopify";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            // request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllShopifyOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<GetAllShopifyOutputModel>(responseStream);
                result = data;

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Product Failed!", $"{data.Error..Message}");
                Console.WriteLine(data.Error.Message);
            }

            return result;
        }

        public async Task UpdateShopify(ShopifyModel input)
        {
            UpdateShopifyModel updateShopifyModel = new()
            {
                Id = input.Id,
                Name = input.Name,
                Number = input.Number,
                Price = input.Price,
                FabricComposition = input.FabricComposition,
                CareInstruction = input.CareInstruction,
                Tags = input.Tags,
                Description = input.Description
            };

            input.MediaFiles.ForEach(x =>
            {
                updateShopifyModel.MediaFiles.Add(new() { MediaFileId = x.MediaFile.Id, OrderNumber = x.OrderNumber });
            });

            var json = JsonSerializer.Serialize(updateShopifyModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/shopify/{input.Id}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Updated!", "", $"/collectionandproduct/product/{input.ProductId}");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }


    }
}
