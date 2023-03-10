using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OBJPatternBlocks.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.LaunchCategories.Dtos;
using SSY.Blazor.HttpClients.Data.Dropdowns.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Dropdowns.Model;
using ExcessListModel = SSY.Blazor.HttpClients.Data.Inventory.Dropdowns.Model.ExcessListModel;

namespace SSY.Blazor.HttpClients.Data.Inventory.Dropdowns;

public class GetDropdownService
{
    public GetDropdownService(IJSRuntime js,
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

    public async Task<T> GetDropdown<T>(string model)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/{model}/GetAll?MaxResultCount=1000";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<T>(responseStream);
            return data;
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            Console.WriteLine(JsonSerializer.Serialize(data.Message));
            return default;
        }
    }

    public async Task<T> GetDropdownWithCategory<T>(string model, int categoryId)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/{model}/GetAll?CategoryId={categoryId}&MaxResultCount=100";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<T>(responseStream);
            return data;
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            Console.WriteLine(JsonSerializer.Serialize(data.Message));
            return default;
        }
    }

    public async Task<string> GetLabel(int id, string model)
    {
        string result = string.Empty;
        var url = $"{_configuration["App:ServerRootAddress"]}/{model}/Get?Id={id}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<DropDownResult>(responseStream);
            result = data.Result.Label;
            return result;
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            Console.WriteLine(JsonSerializer.Serialize(data.Message));
            return default;
        }
    }

    public async Task<MaterialCategoryListModel> GetAllMaterialCategory(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/MaterialCategory/GetAll?";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Inventory");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<MaterialCategoryListModel>(responseStream);
            return data;
        }
        else
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            Console.WriteLine(JsonSerializer.Serialize(data.Message));
            return default;
        }
    }

    public async Task<TypeListModel> GetAllMaterialType(int? categoryId, string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/MaterialType/GetAll?";

        if (categoryId != null)
            url += "CategoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";
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

        TypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<TypeListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();

        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All MaterialType Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<ColorListModel> GetAllColor(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Color/GetAll?";
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

        ColorListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ColorListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<WeightListModel> GetAllWeightUnit(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/WeightUnit/GetAll?";
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

        WeightListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<WeightListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All WeightUnit Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<CompressionListModel> GetAllCompression(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Compression/GetAll?";
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

        CompressionListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<CompressionListModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Compression Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<FabricStretchListModel> GetAllFabricStretch(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/FabricStretch/GetAll?";
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

        FabricStretchListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<FabricStretchListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Fabric Stretch Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<PFPListModel> GetAllPreparedForPrint(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/PreparedForPrint/GetAll?";
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

        PFPListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<PFPListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Prepared For Print Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<RecycledListModel> GetAllRecycled(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Recycled/GetAll?";
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

        RecycledListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<RecycledListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Recycled Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<CreaseListModel> GetAllCrease(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Crease/GetAll?";
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

        CreaseListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<CreaseListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Recycled Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<PrintRepeatListModel> GetAllPrintRepeat(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/PrintRepeat/GetAll?";
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

        PrintRepeatListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<PrintRepeatListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Recycled Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<ExcessListModel> GetAllExcess(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Excess/GetAll?";
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

        ExcessListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ExcessListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Recycled Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<HandFeelListModel> GetAllHandFeel(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/HandFeel/GetAll?";
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

        HandFeelListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<HandFeelListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Recycled Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<GetAllPanelListModel> GetAllPanel(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Panel/GetAll?";
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

        GetAllPanelListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllPanelListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Panel Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<UnitOfMeasurementListModel> GetAllUnitOfMeasurement(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/UnitOfMeasurement/GetAll?";
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

        UnitOfMeasurementListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<UnitOfMeasurementListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All UnitOfMeasurement Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<UpchargeTypeListModel> GetAllUpchargeType(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/UpchargeType/GetAll?";
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

        UpchargeTypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<UpchargeTypeListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All UpchargeType Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<PricingTypeListModel> GetAllPricingTypeListModel(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/PricingType/GetAll?";
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

        PricingTypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<PricingTypeListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All PricingTypeListModel Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }


    public async Task<CareInstructionTypeListModel> GetAllCareInstructionType(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CareInstructionType/GetAll?";
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

        CareInstructionTypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<CareInstructionTypeListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All CareInstructionType Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<CurrencyListModel> GetAllCurrency(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Currency/GetAll?";
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

        CurrencyListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<CurrencyListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Currency Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<ShadingListModel> GetAllShading(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Shading/GetAll?";
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

        ShadingListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ShadingListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Shading Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<SectionListModel> GetAllSection(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CommentSection/GetAll?";
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

        SectionListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<SectionListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<CommentCategoryListModel> GetAllCommentCategory(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CommentCategory/GetAll?";
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

        CommentCategoryListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<CommentCategoryListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }
    public async Task<SubjectListModel> GetAllSubject(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/CommentSubject/GetAll?";
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

        SubjectListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<SubjectListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<ProductTypeListModel> GetAllProductType(string? keyword, string? sorting, int? skipCount, int? maxResultCount = 1000)
    {
        var url = $"{_configuration["App:ProductServerRootAddress"]}/type?";
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

        ProductTypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ProductTypeListModel>(responseStream);
            result = data;
            result.Items = result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<ProductCategoryListModel> GetAllProductCategory(string? keyword, string? sorting, int? skipCount, int? maxResultCount = 1000)
    {
        var url = $"{_configuration["App:ProductServerRootAddress"]}/product-category?";
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

        ProductCategoryListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ProductCategoryListModel>(responseStream);
            result = data;
            result.Items = result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<MaterialTypeListModel> GetAllMaterialType(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/MaterialType/GetAll?";
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

        MaterialTypeListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<MaterialTypeListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<GetAllCompanyOutputModel> GetAllCompany(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/Company/GetAll?";
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

        GetAllCompanyOutputModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<GetAllCompanyOutputModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Name).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Color Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }


    public async Task<OBJPatternBlockListModel> GetAllObjPattern(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/OBJPatternBlock/GetAll?";
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

        OBJPatternBlockListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<OBJPatternBlockListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Currency Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<BaseSizeSpecListModel> GetAllBaseSizeSpec(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/BaseSizeSpec/GetAll?";
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

        BaseSizeSpecListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<BaseSizeSpecListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Currency Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }

    public async Task<WorkmanshipGuideListModel> GetAllWorkmanshipGuide(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
    {
        var url = $"{_configuration["App:ServerRootAddress"]}/WorkmanshipGuide/GetAll?";
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

        WorkmanshipGuideListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<WorkmanshipGuideListModel>(responseStream);
            result = data;
            result.Result.Items = result.Result.Items.OrderBy(o => o.Label).ToList();
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Currency Failed!", $"{data.Error..Message}");
            Console.WriteLine(data.Error.Message);
        }

        return result;
    }


    public async Task<LaunchCategoryListModel> GetAllLaunchCategory(string? keyword, string? sorting, int? skipCount, int? maxResultCount = 1000)
    {
        var url = $"{_configuration["App:ProductServerRootAddress"]}/launch-category?";
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

        LaunchCategoryListModel result = new();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<LaunchCategoryListModel>(responseStream);
            result = data;
        }
        else
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
            //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Failed!", $"{data.Message}");
            Console.WriteLine(data.Message);
        }

        return result;
    }



}

