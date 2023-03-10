using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ChildProducts.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ChildProducts
{
    public class ChildProductService
    {
        public ChildProductService(IJSRuntime js,
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


        public async Task<GetAllChildProductOutputModel> GetAllChildProducts()
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/child-product?MaxResultCount=1000";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllChildProductOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllChildProductOutputModel>(responseStream);
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

        public async Task<ChildProductModel> GetChildProducts(Guid id)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/child-product/{id}";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            ChildProductModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<ChildProductModel>(responseStream);
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

        public async Task CreateChildProduct(CreateChildProductModel input)
        {
            CreateChildProductModel createChildProduct = new()
            {
                Name = input.Name,
                ChildSku = input.ChildSku,
                ColorId = input.ColorId,
                ColorOptionId = input.ColorOptionId,
                ProductTypeId = input.ProductTypeId,
                ProductId = input.ProductId
            };

            var json = JsonSerializer.Serialize(createChildProduct);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/child-product";

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

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/collectionandproduct/collections/details/{input.CollectionId}");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task CreateBulkChildProduct(List<CreateChildProductModel> input)
        {
            List<CreateChildProductModel> createChildProductModels = new();
            Guid collectionId = Guid.Empty;
            input.ForEach(x =>
            {
                createChildProductModels.Add(new()
                {
                    Name = x.Name,
                    ChildSku = x.ChildSku,
                    ColorId = x.ColorId,
                    ProductTypeId = x.ProductTypeId,
                    ColorOptionId = x.ColorOptionId,
                    ProductId = x.ProductId
                });
                collectionId = x.CollectionId;
            });

            var json = JsonSerializer.Serialize(createChildProductModels);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/child-product/child-product-list";

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

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/collectionandproduct/collections/details/{collectionId}");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

    }
}

