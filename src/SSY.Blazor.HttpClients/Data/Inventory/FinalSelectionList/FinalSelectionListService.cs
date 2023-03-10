using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList.Model;
//using SSY.Web.Blazor.Core.Data.Mails;

namespace SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList
{

    public class FinalSelectionListService
    {
        public FinalSelectionListService(IJSRuntime js,
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
        public async Task<GetAllFinalSelectionListOutputModel> GetAllFinalSelectionList(string? keyword, int companyId, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/FinalSelectionList/GetAll?";

            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (companyId != 0)
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

            GetAllFinalSelectionListOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllFinalSelectionListOutputModel>(responseStream);
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
        public async Task<CreateOutputFinalSelectionListModel> CreateFinalSelectionList(FinalSelectionListModel input)
        {
            CreateOutputFinalSelectionListModel results = new();

            CreateFinalSelectionListModel finalSelectionListModel = new()
            {
                TenantId = input.TenantId,
                IsActive = input.IsActive,
                CompanyId = input.CompanyId,
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

            var json = JsonSerializer.Serialize(finalSelectionListModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/FinalSelectionList/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var commentResponseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOutputFinalSelectionListModel>(commentResponseStream);
                results = data;

                // Send Email
                //await _mailService.SendFinalSelectionListEmailAsync(input.CompanyId);

                await _js.InvokeVoidAsync("defaultMessage", "success", "Final Selection Added", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Final Selection Added Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

            return results;
        }
    }
}

