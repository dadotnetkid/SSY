using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;

//using SSY.Web.Blazor.Core.Data.Mails;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides;

public class WorkmanshipGuideListService
{
    public WorkmanshipGuideListService(IJSRuntime js,
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

    public async Task<GetAllWorkmanshipGuideListOutputModel> GetAllWorkmanshipGuideLists(string? keyword, int? typeId, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/WorkmanshipGuide/GetAll?";

        if (keyword != null)
            url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
        if (typeId != 0)
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

        GetAllWorkmanshipGuideListOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllWorkmanshipGuideListOutputModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Workmanship Guide Failed!", $"{data.Message}");
            Console.WriteLine(data.Message);
        }

        return result;
    }

    //public async Task<CreateOutputWorkmanshipGuideListModel> CreateWorkmanshipGuideList(WorkmanshipGuideListModel input)
    //{
    //    CreateOutputWorkmanshipGuideListModel results = new();

    //    CreateOutputWorkmanshipGuideListModel workmanshipGuideListModel = new()
    //    {
    //        TenantId = input.TenantId,
    //        IsActive = input.IsActive,
    //        TypeId = input.TypeId,
    //        // MediaFile = new()
    //        // {
    //        //     FilePath = input.MediaFile.FilePath,
    //        //     OriginalFileName = input.MediaFile.OriginalFileName
    //        // }
    //    };

    //    var json = JsonSerializer.Serialize(workmanshipGuideListModel);

    //    Console.WriteLine(json);

    //    var content = new StringContent(json, Encoding.UTF8, "application/json");
    //    var url = $"{_configuration["App:ServerRootAddress"]}/WorkmanshipGuide/Create";

    //    var request = new HttpRequestMessage(HttpMethod.Post, url);
    //    request.Headers.Add("Accept", "*/*");
    //    request.Headers.Add("User-Agent", "Inventory");
    //    request.Content = content;

    //    var client = _clientFactory.CreateClient();

    //    var response = await client.SendAsync(request);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        using var commentResponseStream = await response.Content.ReadAsStreamAsync();
    //        var data = await JsonSerializer.DeserializeAsync<CreateOutputWorkmanshipGuideListModel>(commentResponseStream);
    //        results = data;

    //        // Send Email

    //        await _js.InvokeVoidAsync("defaultMessage", "success", "Workmanship Guide Added", "");
    //    }
    //    else
    //    {
    //        using var responseStream = await response.Content.ReadAsStreamAsync();
    //        var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
    //        await _js.InvokeVoidAsync("defaultMessage", "error", "Final Selection Added Failed!", $"{data.Error.Message}");
    //        System.Console.WriteLine(data.Error.Message);
    //    }

    //    return results;
    //}

    public async Task<CreateOutputWorkmanshipGuideListModel> CreateWorkmanshipGuideList(WorkmanshipGuideListModel input)
    {
        CreateOutputWorkmanshipGuideListModel results = new();

        CreateWorkmanshipGuideListModel workmanshipGuideListModel = new()
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

        var json = JsonSerializer.Serialize(workmanshipGuideListModel);

        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/WorkmanshipGuide/Create";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var commentResponseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<CreateOutputWorkmanshipGuideListModel>(commentResponseStream);
            results = data;

            await _js.InvokeVoidAsync("defaultMessage", "success", "Workmanship Guide Added", "");

        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Workmanship Guide Added Failed!", $"{data.Error.Message}");
            Console.WriteLine(data.Error.Message);
        }

        return results;
    }
}


