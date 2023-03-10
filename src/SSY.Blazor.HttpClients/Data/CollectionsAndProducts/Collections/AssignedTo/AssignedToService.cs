using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo;

public class AssignedToService
{
    public AssignedToService(IJSRuntime js,
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


    public async Task<GetAllAssignedToModel> GetAllAssignedTo(Guid? collectionId, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionAssignedTo/GetAll?";

        if (collectionId != null)
            url += "CategoryId=" + HttpUtility.UrlEncode("" + collectionId) + "&";
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

        GetAllAssignedToModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllAssignedToModel>(responseStream);
            result = data;
        }
        else
        {
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Failed!", "");
            System.Console.WriteLine(response.Content.ToString());
        }

        return result;
    }


    public async Task<GetAssignedToModel> GetAssignedTo(int id)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionAssignedTo/Get?Id={id}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/* ");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        GetAssignedToModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAssignedToModel>(responseStream);
            result = data;
        }
        else
        {
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Type Failed!", "");
            System.Console.WriteLine(response.Content.ToString());
        }
        return result;
    }

    public async Task CreateAssignedTo(CreateAssignedToModel input)
    {
        var json = JsonSerializer.Serialize(input);
        System.Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionAssignedTo/Create";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            //var data = await JsonSerializer.DeserializeAsync<CreateReservationMaterialTypeOutputModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "success", "Assigned Success!", "");
            //await GetReservationMaterialType(data.Result.Value);
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

    public async Task UpdateAssignedTo(UpdateAssignedToModel input)
    {
        var json = JsonSerializer.Serialize(input);
        System.Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionAssignedTo/Update";

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

    public async Task DeleteAssignedTo(Guid id)
    {
        DeleteAssignedToModel assigned = new() { Id = id };

        var json = JsonSerializer.Serialize(assigned);
        Console.WriteLine(json);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ServerRootAddress"]}/CollectionAssignedTo/Delete?Id={id}";

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
            await GetAllAssignedTo(null, null, null, 100);
            //var data = await JsonSerializer.DeserializeAsync<GetReservationMaterialTypeOutputModel>(responseStream);
            //result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{data.Message}");
            System.Console.WriteLine(data.Message);
        }
    }
}

