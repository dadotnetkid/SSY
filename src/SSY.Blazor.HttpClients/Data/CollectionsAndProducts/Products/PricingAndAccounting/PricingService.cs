using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting;

public class PricingService
{
    public PricingService(IJSRuntime js,
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

    public async Task CreatePricing(CreatePricingModel input)
    {
        var json = JsonSerializer.Serialize(input);
        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ProductServerRootAddress"]}/pricing";

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

    public async Task<GetPricingOutputModel> GetPricing(int id)
    {
        GetPricingOutputModel result = new();
        var url = $"{_configuration["App:ProductServerRootAddress"]}/pricing/{id}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<GetPricingOutputModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            Console.WriteLine(data.Message);
        }

        return result;
    }

    public async Task UpdatePricing(UpdatePricingModel input, Guid id)
    {
        var json = JsonSerializer.Serialize(input);
        Console.WriteLine(json);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"{_configuration["App:ProductServerRootAddress"]}/pricing/{id}";

        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        request.Content = content;

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            await _js.InvokeVoidAsync("defaultMessage", "success", "Update Success!", "");
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

    public async Task DeletePricing(Guid id)
    {
        var url = $"{_configuration["App:ProductServerRootAddress"]}/pricing/{id}";

        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("Accept", "*/*");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Sucess!", "");
            }
        }
        else
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }
    }


}

