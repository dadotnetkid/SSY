using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Services.IST.Models;

namespace SSY.Blazor.HttpClients.Services.IST
{
    public class ISTService
    {
        public ISTService(IJSRuntime js,
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

        public async Task<List<ExcessMarkApprovedMessage>> ExcessApproval()
        {

            ExcessMarkApprovedModel ExcessMarkApprovedModel = new()
            {
                CMD = "MarkApprovedFab",
                PAccessKey = "4906C597-1E80-4457-9583-89B877BC6E2B",
                OfferNo = "1",
                MatNo = "01002373-00000,01003162-00028",
                IsApproved = true,
                ApprovedBy = "rey"
            };

            var json = JsonSerializer.Serialize(ExcessMarkApprovedModel);

            Console.WriteLine(json);

            var url = "https://api-imapps.luenthai.com/iPlex2Live/GenConn";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            List<ExcessMarkApprovedMessage> ExcessMarkApprovedMessage = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<List<ExcessMarkApprovedMessage>>(responseStream);
                ExcessMarkApprovedMessage = data;
                Console.WriteLine(JsonSerializer.Serialize(ExcessMarkApprovedMessage));


            }
            else
            {
                Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
                return default;
            }

            return ExcessMarkApprovedMessage;

        }
    }
}