using System;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes
{
    public class AdditionRequestTypeService
    {
        public AdditionRequestTypeService(IJSRuntime js,
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

        public async Task<GetAllAdditionRequestTypeOutputModel> GetAllAdditionRequestType(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/AdditionRequestType/GetAll?";

            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
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

            GetAllAdditionRequestTypeOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllAdditionRequestTypeOutputModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
                Console.WriteLine(response.Content.ToString());
            }

            return result;
        }

        public async Task<GetAdditionRequestTypeOutputModel> GetAdditionRequestType(int id)
        {
            GetAdditionRequestTypeOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/AdditionRequest/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAdditionRequestTypeOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get ReservationColor Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }
    }
}

