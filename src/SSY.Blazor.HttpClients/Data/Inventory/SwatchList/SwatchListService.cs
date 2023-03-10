using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.SwatchList.Model;
//using SSY.Web.Blazor.Core.Data.Mails;

namespace SSY.Blazor.HttpClients.Data.Inventory.SwatchList
{

    public class SwatchListService
    {
        public SwatchListService(IJSRuntime js,
        IHttpClientFactory clientFactory,
        NavigationManager navigationManager,
        IConfiguration configuration)
        {
            _js = js;
            _clientFactory = clientFactory;
            _navigationManager = navigationManager;
            _configuration = configuration;
            //_mailService = new(_js, _clientFactory, _navigationManager, _configuration);
        }

        #region Injects

        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _clientFactory;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        //private readonly MailService _mailService;

        #endregion
        public async Task<GetAllSwatchListOutputModel> GetAllSwatchList(string? keyword, int companyId, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SwatchList/GetAll?";

            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (companyId != null)
                url += "CompanyId=" + HttpUtility.UrlEncode("" + companyId) + "&";
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

            GetAllSwatchListOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllSwatchListOutputModel>(responseStream);
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
        public async Task<CreateOutputSwatchListModel> CreateSwatchList(SwatchListModel input)
        {
            CreateOutputSwatchListModel results = new();

            CreateSwatchListModel swatchListModel = new()
            {
                TenantId = input.TenantId,
                IsActive = input.IsActive,
                CompanyId = input.CompanyId,
                IsReceived = input.IsReceived,
                MediaFile = new()
                {
                    TenantId = input.TenantId,
                    IsActive = input.IsActive,
                    StorageFileName = input.MediaFile.StorageFileName,
                    FilePath = input.MediaFile.FilePath,
                    ContentDisposition = input.MediaFile.ContentDisposition,
                    ContentType = input.MediaFile.ContentType,
                    FileName = input.MediaFile.FileName,
                    Name = input.MediaFile.Name,
                    MediaFileType = 0
                },
                AddedBy = input.AddedBy
            };

            var json = JsonSerializer.Serialize(swatchListModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SwatchList/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOutputSwatchListModel>(commentResponseStream);
                results = data;

                // Send Email
                //await _mailService.SendSwatchListEmailAsync(input.CompanyId);

                await _js.InvokeVoidAsync("defaultMessage", "success", "SwatchList Added", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "SwatchList Added Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

            return results;
        }


        public async Task ChangeReceivedStatusAsync(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SwatchList/ChangeReceivedStatus?";
            if (id != null)
                url += "id=" + HttpUtility.UrlEncode("" + id) + "&";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                // add swal message 
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }
    }
}

