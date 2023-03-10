using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace SSY.Blazor.HttpClients.Data.Inventory.Mails
{
    public class MailService
    {
        public MailService(IJSRuntime js,
        IHttpClientFactory clientFactory,
        NavigationManager navigationManager,
        IConfiguration configuration)
        {
            _js = js;
            _clientFactory = clientFactory;
            _navigationManager = navigationManager;
            _configuration = configuration;
        }

        #region Injects

        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;

        #endregion

        public async Task SendExcessListEmailAsync(int companyId)
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendExcessListEmail?companyId={companyId}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

        }

        public async Task SendSwatchListEmailAsync(int companyId)
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendSwatchListEmail?companyId={companyId}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

        }

        public async Task SendFinalSelectionListEmailAsync(int companyId)
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendFinalSelectionListEmail?companyId={companyId}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task SendMinimumStockLevelEmailAsync(Guid materialId)
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendMinimumStockLevelEmail?materialName={materialId}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task SendRequestForBulkPOForMaterialEmailAsync()
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendRequestForBulkPOForMaterialEmail";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task SendReservationForMaterialEmailAsync()
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendReservationForMaterialEmail";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task SendReservationForMaterialOffSiteEmailAsync()
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendReservationForMaterialOffSiteEmail";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task SendCollectionHasBeenAssignedEmailAsync()
        {
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Mail/SendCollectionHasBeenAssignedEmail";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            //request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                //var data = await JsonSerializer.DeserializeAsync<CreateOutputExcessListModel>(commentResponseStream);
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Email Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

    }
}
