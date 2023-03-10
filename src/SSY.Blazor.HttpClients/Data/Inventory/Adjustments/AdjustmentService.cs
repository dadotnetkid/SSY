using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments
{
    public class AdjustmentService
    {
        public AdjustmentService(IJSRuntime js,
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

        public async Task<GetAllAdjustmentOutputModel> GetAllAdjustment(Guid materialId, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Adjustment/GetAll?";
            url += "MaterialId=" + HttpUtility.UrlEncode("" + materialId) + "&";
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

            GetAllAdjustmentOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllAdjustmentOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Adjustment Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetAdjustmentOutputModel> GetAdjustment(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Adjustment/Get?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAdjustmentOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAdjustmentOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Location Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task CreateMaterialAdjustment(List<AdjustmentModel> adjustments)
        {
            List<CreateAdjusmentModel> createAdjusments = new();

            adjustments.ForEach(x =>
            {
                createAdjusments.Add(new CreateAdjusmentModel()
                {
                    TenantId = x.TenantId,
                    IsActive = x.IsActive,
                    RollId = x.RollId,
                    ActionId = x.ActionId,
                    Date = x.Date,
                    Remarks = x.Remarks,
                    To = x.To,
                    From = x.From
                });
            });

            var json = JsonSerializer.Serialize(createAdjusments);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Adjustment/CreateRollAdjustment";

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

                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Adjustment Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> CreateSubMaterialAdjustment(AdjustmentModel adjustment)
        {
            CreateSubMaterialAdjustmentModel adjusmentModel = new()
            {
                TenantId = adjustment.TenantId,
                IsActive = adjustment.IsActive,
                ActionId = adjustment.ActionId,
                SubMaterialId = adjustment.MaterialId,
                Date = adjustment.Date,
                Remarks = adjustment.Remarks,
                To = adjustment.To
            };

            var json = JsonSerializer.Serialize(adjusmentModel);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Adjustment/CreateSubMaterialAdjustment";

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
                await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
                return response.IsSuccessStatusCode;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Adjustment Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
                return false;
            }
        }

    }
}

