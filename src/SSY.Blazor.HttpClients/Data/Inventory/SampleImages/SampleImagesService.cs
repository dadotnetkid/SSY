//NOTE DITO LALAGAY ANG LOGIC SA BACKEND(API CALLS)
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.SampleImages.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.SampleImages
{

    public class SampleImagesService
    {
        public SampleImagesService(IJSRuntime js,
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

        public async Task<SampleImagesListModel> GetAllSampleImages()
        {
            // var url = $"{_configuration["App:ServerRootAddress"]}/Accountability/Get?Id={id}";

            // var request = new HttpRequestMessage(HttpMethod.Get, url);
            // request.Headers.Add("Accept", "*/* ");
            // request.Headers.Add("User-Agent", "Inventory");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            SampleImagesListModel result = new();

            // if (response.IsSuccessStatusCode)
            // {
            //     using var responseStream = await response.Content.ReadAsStreamAsync();

            //     var data = await JsonSerializer.DeserializeAsync<BankDetailModel>(responseStream);
            //     result = data;
            // }
            // else
            // {
            //     //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Accountability Failed!", "");
            //     System.Console.WriteLine(response.Content.ToString());
            // }
            result.SampleImages.Add(new SampleImagesModel()
            {
                Photo = "",
                Status = "New",
                DateUpdated = "05/05/2022",
                Influencer = "test",
                DesignName = "Test",
                Product = "SHO",
                Collection = "TBC",
                Ver = 1,
                Designer = "Test"
            });
            result.SampleImages.Add(new SampleImagesModel()
            {
                Photo = "",
                Status = "New",
                DateUpdated = "05/05/2022",
                Influencer = "asff",
                DesignName = "Teasqwest",
                Product = "SHO",
                Collection = "TBC",
                Ver = 1,
                Designer = "Test"
            });
            return result;
        }

    }
}

