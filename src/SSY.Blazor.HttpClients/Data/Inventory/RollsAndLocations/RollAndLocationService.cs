using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations
{
    public class RollAndLocationService
    {
        public RollAndLocationService(IJSRuntime js,
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

        public async Task<GetAllRollAndLocationOutputModel> GetAllRollAndLocation(Guid materialId, string? keyword, bool? isDeleted, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/RollAndLocation/GetAll?";
            url += "MaterialId=" + HttpUtility.UrlEncode("" + materialId) + "&";
            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (isDeleted != null)
                url += "IsDeleted=" + HttpUtility.UrlEncode("" + isDeleted) + "&";
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

            GetAllRollAndLocationOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllRollAndLocationOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Rolls And Locations Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetRollAndLocationOutputModel> GetRollAndLocation(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/RollAndLocation/Get?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetRollAndLocationOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetRollAndLocationOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Roll And Location Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task UpdateRollAndLocation(RollAndLocationModel rollAndLocation)
        {
            UpdateRollAndLocationModel rollAndLocationModel = new()
            {
                Id = rollAndLocation.Id,
                TenantId = rollAndLocation.TenantId,
                IsActive = rollAndLocation.IsActive,
                MaterialId = rollAndLocation.MaterialId,
                QR = rollAndLocation.QR,
                RollNumber = rollAndLocation.RollNumber,
                DateAcquired = rollAndLocation.DateAcquired,
                ShelfLife = rollAndLocation.ShelfLife,
                TotalCount = rollAndLocation.TotalCount,
                OnHandCount = rollAndLocation.OnHandCount,
                AvailableCount = rollAndLocation.AvailableCount,
                ConsumeBeforeDate = rollAndLocation.ConsumeBeforeDate,
                ShadingId = rollAndLocation.ShadingId,
                BuildingOrWarehouse = rollAndLocation.BuildingOrWarehouse,
                TRackNumber = rollAndLocation.TRackNumber,
                Rack = rollAndLocation.Rack,
                PONumber = rollAndLocation.PONumber,
                ShippedCount = rollAndLocation.ShippedCount,
                ReceivedCount = rollAndLocation.ReceivedCount,
                IncomingCount = rollAndLocation.IncomingCount
            };

            var json = JsonSerializer.Serialize(rollAndLocationModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/RollAndLocation/Update";

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var adjustmentResponseStream = await response.Content.ReadAsStreamAsync();
                //var result = await JsonSerializer.DeserializeAsync<GetAdjustmentOutputModel>(adjustmentResponseStream);

                await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Roll And Location Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task CreateRollAndLocation(RollAndLocationModel rollAndLocation)
        {
            CreateRollAndLocationModel rollAndLocationModel = new()
            {
                TenantId = rollAndLocation.TenantId,
                IsActive = rollAndLocation.IsActive,
                MaterialId = rollAndLocation.MaterialId,
                QR = rollAndLocation.QR,
                RollNumber = rollAndLocation.RollNumber,
                DateAcquired = rollAndLocation.DateAcquired,
                ShelfLife = rollAndLocation.ShelfLife,
                TotalCount = rollAndLocation.TotalCount,
                OnHandCount = rollAndLocation.OnHandCount,
                AvailableCount = rollAndLocation.AvailableCount,
                ConsumeBeforeDate = rollAndLocation.ConsumeBeforeDate,
                ShadingId = rollAndLocation.ShadingId,
                BuildingOrWarehouse = rollAndLocation.BuildingOrWarehouse,
                TRackNumber = rollAndLocation.TRackNumber,
                Rack = rollAndLocation.Rack,
                PONumber = rollAndLocation.PONumber,
                ShippedCount = rollAndLocation.ShippedCount,
                ReceivedCount = rollAndLocation.ReceivedCount,
                IncomingCount = rollAndLocation.IncomingCount
            };

            var json = JsonSerializer.Serialize(rollAndLocationModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/RollAndLocation/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var adjustmentResponseStream = await response.Content.ReadAsStreamAsync();
                //var result = await JsonSerializer.DeserializeAsync<GetAdjustmentOutputModel>(adjustmentResponseStream);

                await _js.InvokeVoidAsync("defaultMessage", "success", "Create Success!", "");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Creating Roll And Location Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task DeleteRollAndLocation(Guid id)
        {
            DeleteRollAndLocationModel rollAndLocation = new() { Id = id };

            var json = JsonSerializer.Serialize(rollAndLocation);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/RollAndLocation/Delete?Id={id}";

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
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }

        }

    }
}

