using System;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace SSY.Blazor.HttpClients.Services
{
    public class DeleteDataByIdService
    {
        public DeleteDataByIdService(IJSRuntime js,
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

        public async Task<T> DeleteDataById<T>(Guid id, string model)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/{model}/Delete?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<T>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "success", "Deleted Successfully.", "");
                return data;
            }
            else
            {
                Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
                return default;
            }
        }
    }
}

