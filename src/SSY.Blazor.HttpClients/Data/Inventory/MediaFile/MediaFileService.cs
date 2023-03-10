using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;
using GetAllMediaFileOutputModel = SSY.Blazor.HttpClients.Models.Inventory.MediaFiles.GetAllMediaFileOutputModel;
using MediaFileBase64Model = SSY.Blazor.HttpClients.Models.Inventory.MediaFiles.MediaFileBase64Model;
using MediaFileListResult = SSY.Blazor.HttpClients.Models.Inventory.MediaFiles.MediaFileListResult;


namespace SSY.Blazor.HttpClients.Data.Inventory.MediaFile;

public class MediaFileService
{
    public MediaFileService(IJSRuntime js,
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

    //  public async Task UpdateMediaV2(GetAllMediaFileOutputModel input)
    // {

    //     var json = JsonSerializer.Serialize(input);

    //     Console.WriteLine(json);

    //     var url = $"{_configuration["App:ServerRootAddress"]}/MediaFile/UpdateListUpload";

    //     var content = new StringContent(json, Encoding.UTF8, "application/json");
    //     var request = new HttpRequestMessage(HttpMethod.Put, url);
    //     request.Headers.Add("Accept", "*/*");
    //     request.Headers.Add("User-Agent", "Inventory");
    //     request.Content = content;

    //     var client = _clientFactory.CreateClient();
    //     var response = await client.SendAsync(request);

    //     if (response.IsSuccessStatusCode)
    //     {
    //         using var responseStream = await response.Content.ReadAsStreamAsync();
    //     }
    //     else
    //     {
    //         using var responseStream = await response.Content.ReadAsStreamAsync();
    //         var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
    //         await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
    //         Console.WriteLine(data.Error.Message);
    //     }
    // }

    public async Task<List<Guid>> CreateListMediaFile(List<MediaFileModel> input)
    {
        var json = JsonSerializer.Serialize(input);

        Console.WriteLine(json);
        List<Guid> result = new();
        var url = $"{_configuration["App:ServerRootAddress"]}/MediaFile/ListUpload";

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<MediaFileListResult>(responseStream);
            result = data.Ids;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
            Console.WriteLine(data.Error.Message);
        }
        return result;
    }

    public async Task<List<MediaFileModel>> CreateListMediaFileProduct(List<CreateMediaFileModel> input)
    {
        var json = JsonSerializer.Serialize(input);

        Console.WriteLine(json);
        List<MediaFileModel> result = new();
        var url = $"{_configuration["App:ProductServerRootAddress"]}/media-file/list-upload";

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<List<MediaFileModel>>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
            Console.WriteLine(data.Error.Message);
        }
        return result;
    }

    public async Task<string> FileDownload(Guid id)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/MediaFile/FileDownload?MediaFileId={id}";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/* ");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        string result = string.Empty;
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<MediaFileBase64Model>(responseStream);
            result = data.Result;
        }
        else
        {
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Accountability Failed!", "");
            Console.WriteLine(response.Content.ToString());
        }

        return result;
    }


    public async Task<GetAllMediaFileOutputModel> GetAllProductMediaFile(string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ProductServerRootAddress"]}/media-file";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        // request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetAllMediaFileOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<GetAllMediaFileOutputModel>(responseStream);
            result = data;

        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Product Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<GetAllMediaFileOutputModel> GetAllMediaFile(string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/MediaFile/GetAll";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        // request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetAllMediaFileOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<GetAllMediaFileOutputModel>(responseStream);
            result = data;

        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Product Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }




    // Product Media File 

    public async Task<MediaFileModel> CreateProductMediaFile(CreateMediaFileModel input)
    {
        var json = JsonSerializer.Serialize(input);

        Console.WriteLine(json);
        MediaFileModel result = new();
        var url = $"{_configuration["App:ProductServerRootAddress"]}/media-file";

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<MediaFileModel>(responseStream);

            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
            Console.WriteLine(data.Error.Message);
        }
        return result;
    }
}