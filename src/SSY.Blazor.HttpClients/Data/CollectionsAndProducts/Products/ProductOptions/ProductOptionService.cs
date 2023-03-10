using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Models;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions
{
    public class ProductOptionService
    {
        public ProductOptionService(IJSRuntime js,
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

        public async Task<GetAllProductOptionDropdownOutputModel> GetAllProductOptionDropdown(string? label, int? productTypeId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/ProductOption/GetAllProductTypeOptions?MaxResultCount=1000&";
            if (label != null)
                url += "Label=" + HttpUtility.UrlEncode("" + label) + "&";
            if (productTypeId != null)
                url += "ProductTypeId=" + HttpUtility.UrlEncode("" + productTypeId) + "&";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllProductOptionDropdownOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllProductOptionDropdownOutputModel>(responseStream);
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

        public async Task<GetAllProductOptionDropdownOutputModel> GetAllProductOptionsDropdown(string? label, int? productTypeId, int? parentId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/ProductOption/GetAll?MaxResultCount=1000&";
            if (label != null)
                url += "Label=" + HttpUtility.UrlEncode("" + label) + "&";
            if (productTypeId != null)
                url += "ProductTypeId=" + HttpUtility.UrlEncode("" + productTypeId) + "&";
            if (parentId != null)
                url += "ParentId=" + HttpUtility.UrlEncode("" + parentId) + "&";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllProductOptionDropdownOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllProductOptionDropdownOutputModel>(responseStream);
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

        public async Task<GetAllTypeOptionNamesModel> GetAllProductOptionsDropdownNames(string label)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/ProductOption/GetAllTypeOptionNames?Label={HttpUtility.UrlEncode("" + label)}";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllTypeOptionNamesModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllTypeOptionNamesModel>(responseStream);
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

        public async Task<GetProductOptionsModel> GetProductTypeOptions(int productTypeId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/ProductOption/GetProductOptions?ProductTypeId={productTypeId}";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetProductOptionsModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetProductOptionsModel>(responseStream);
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

        public async Task UpdateProductOption(List<UpdateProductOptionDto> input)
        {
            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/options";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    await _js.InvokeVoidAsync("defaultMessage", "success", "Product Option Successfully Added!", "");
                }
            }
            else
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }
        }

        public async Task<GetProductOptionOutputModel> GetProductOption(Guid id)
        {
            GetProductOptionOutputModel result = new();

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product-option/{id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    result = await JsonSerializer.DeserializeAsync<GetProductOptionOutputModel>(responseStream);
                }
            }
            else
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }

            return result;
        }

        public async Task UpdateProductOption(Guid id, UpdateProductOptionModel input)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product-option/{id}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/productoption/");
                }
            }
            else
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }
        }

        public async Task DeleteProductOption(Guid id)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/product-option/{id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Sucess!", "");
                }
            }
            else
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    var error = data.Error;
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                    Console.WriteLine(JsonSerializer.Serialize(error));
                }
            }
        }

    }
}