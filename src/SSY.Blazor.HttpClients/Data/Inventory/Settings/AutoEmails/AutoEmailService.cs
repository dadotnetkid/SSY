using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Settings.AutoEmails.Dtos;

namespace SSY.Blazor.HttpClients.Data.Inventory.Settings.AutoEmails;

public class AutoEmailService
{
    public AutoEmailService(IJSRuntime js,
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

    public async Task<GetAllAutoEmailOutputDto> GetAllAutoEmails(int? emailCategoryId, string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Mail/GetAll?";
        if (emailCategoryId != null)
            url += "EmailCategoryId=" + HttpUtility.UrlEncode("" + emailCategoryId) + "&";
        if (keyword != null)
            url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
        if (sorting != null)
            url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
        if (skipCount != null)
            url += "SkipCount=" + HttpUtility.UrlEncode("" + skipCount) + "&";
        if (maxResultCount != null)
            url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount);
        url = url.Replace("/[?&]$/", "");


        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/* ");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetAllAutoEmailOutputDto result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllAutoEmailOutputDto>(responseStream);
            result = data;
            //result.Result.Items = result.Result.Items.OrderBy(o => o.EmailCategoryId).ToList();
        }
        else
        {
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Failed!", "");
            Console.WriteLine(response.Content.ToString());
        }

        return result;
    }

    public async Task CreateAutoEmail(CreateAutoEmailDto input)
    {
        var json = JsonSerializer.Serialize(input);
        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/Mail/Create";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            await _js.InvokeVoidAsync("defaultMessage", "success", "Add Success!", "");
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            var error = data.Error;
            await _js.InvokeVoidAsync("defaultMessage", "error", "Add Failed!", $"{error.Message}");
            Console.WriteLine(JsonSerializer.Serialize(error));
        }
    }

    public async Task<GetAutoEmailDto> GetAutoEmail(Guid id)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Mail/Get?Id={id}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/* ");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetAutoEmailDto result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAutoEmailDto>(responseStream);
            result = data;
        }
        else
        {
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
            Console.WriteLine(response.Content.ToString());
        }
        return result;
    }

    public async Task UpdateAutoEmail(UpdateAutoEmailDto input)
    {
        var json = JsonSerializer.Serialize(input);
        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/Mail/Update";

        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            //var data = await JsonSerializer.DeserializeAsync<UpdateReservationColorOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
            //await GetReservationColor(data.Result.Value);
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            var error = data.Error;
            await _js.InvokeVoidAsync("defaultMessage", "error", "Update Failed!", $"{error.Message}");
            Console.WriteLine(JsonSerializer.Serialize(error));
        }
    }

    public async Task DeleteAutoEmail(Guid id)
    {
        DeleteAutoEmailDto input = new() { Id = id };

        var json = JsonSerializer.Serialize(input);
        Console.WriteLine(json);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/Mail/Delete?Id={id}";

        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
            await GetAllAutoEmails(null, null, null, null, 100);
            //var data = await JsonSerializer.DeserializeAsync<GetReservationMaterialTypeOutputModel>(responseStream);
            //result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{data.Message}");
            Console.WriteLine(data.Message);
        }
    }
}

