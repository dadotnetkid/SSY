using System;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.Statuses.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses;

public class CollectionStatusService
{
    public CollectionStatusService(IJSRuntime js,
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

    public async Task<GetAllCollectionStatusOutputModel> GetAllCollectionStatus(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionStatus/GetAll?";
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

        GetAllCollectionStatusOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllCollectionStatusOutputModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Failed!", $"{data.Message}");
            System.Console.WriteLine(data.Message);
        }

        return result;
    }

    public async Task<GetCollectionStatusOutputModel> GetCollectionStatus(int id)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionStatus/Get?Id={id}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/* ");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetCollectionStatusOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetCollectionStatusOutputModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Failed!", $"{data.Message}");
            System.Console.WriteLine(data.Message);
        }

        return result;
    }


}

