//NOTE DITO LALAGAY ANG LOGIC SA BACKEND(API CALLS)
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.GeneratedMeasurements.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.GeneratedMeasurements
{

    public class GeneratedMeasurementsService
    {
        public GeneratedMeasurementsService(IJSRuntime js,
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

        public async Task<GeneratedMeasurementsModel> GetGeneratedMeasurements()
        {
            // var url = $"{_configuration["App:ServerRootAddress"]}/Accountability/Get?Id={id}";

            // var request = new HttpRequestMessage(HttpMethod.Get, url);
            // request.Headers.Add("Accept", "*/* ");
            // request.Headers.Add("User-Agent", "Inventory");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            GeneratedMeasurementsModel result = new();

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

            result.AboveBustGirth = 312;
            result.WaistGirth = 123;
            result.LowerWaistGirth = 124;
            result.HipGirth = 5125;
            result.ShoulderLength = 1231;
            result.NeckGirth = 123;
            result.BackWaistLength = 5125;
            result.LowWaistGirth = 125;
            result.ArmHoleGirth = 125;
            result.ArmLength = 125;
            result.KneeGirth = 125;
            result.CalfGirth = 125;
            result.CrotchLength = 125;
            result.SideSeam = 125;
            result.InSeam = 125;
            result.AcrossFont = 125;
            result.AcrossBack = 125;
            result.InSeamAnkle = 125;
            result.ChestWidth = 125;
            result.BustGirth = 125;


            return result;
        }

    }
}

