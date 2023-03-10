using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs;

public class BaseSizeSpecListService
{
    public BaseSizeSpecListService(IJSRuntime js,
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

    public async Task<GetAllBaseSizeSpecListModel> GetAllBaseSizeSpecLists(string? keyword, int? typeId, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/BaseSizeSpec/GetAll?";

        if (keyword != null)
            url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
        if (typeId != null)
            url += "CompanyId=" + HttpUtility.UrlEncode("" + typeId) + "&";
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

        GetAllBaseSizeSpecListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllBaseSizeSpecListModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Base Size Spec Failed!", $"{data.Message}");
            Console.WriteLine(data.Message);
        }

        return result;
    }

    public async Task<CreateOutputBaseSizeSpecListModel> CreateBaseSizeSpecList(BaseSizeSpecListModel input)
    {
        CreateOutputBaseSizeSpecListModel results = new();

        CreateBaseSizeSpecListModel baseSizeSpecListModel = new()
        {
            TenantId = input.TenantId,
            IsActive = input.IsActive,
            TypeId = input.TypeId,
            MediaFile = new()
            {
                StorageFileName = input.MediaFile.StorageFileName,
                FilePath = input.MediaFile.FilePath,
                ContentDisposition = input.MediaFile.ContentDisposition,
                ContentType = input.MediaFile.ContentType,
                FileName = input.MediaFile.FileName,
                Name = input.MediaFile.Name,
                MediaFileType = 0
            },
            //AddedBy = input.AddedBy
        };

        var json = JsonSerializer.Serialize(baseSizeSpecListModel);

        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/BaseSizeSpec/Create";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var commentResponseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<CreateOutputBaseSizeSpecListModel>(commentResponseStream);
            results = data;

            await _js.InvokeVoidAsync("defaultMessage", "success", "Base Size Specs Added", "");

        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Base Size Specs Failed!", $"{data.Error.Message}");
            Console.WriteLine(data.Error.Message);
        }

        return results;
    }
}

