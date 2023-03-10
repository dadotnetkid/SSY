//NOTE DITO LALAGAY ANG LOGIC SA BACKEND(API CALLS)
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.AccountInformation.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.AccountInformation
{

    public class AccountInformationService
    {
        public AccountInformationService(IJSRuntime js,
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

        public async Task<PersonalInformationModel> GetPersonalInformation()
        {
            // var url = $"{_configuration["App:ServerRootAddress"]}/Accountability/Get?Id={id}";

            // var request = new HttpRequestMessage(HttpMethod.Get, url);
            // request.Headers.Add("Accept", "*/* ");
            // request.Headers.Add("User-Agent", "Inventory");

            // var client = _clientFactory.CreateClient();
            // var response = await client.SendAsync(request);

            PersonalInformationModel result = new();

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

            result.FirstName = "Test";
            result.LastName = "Test";
            result.CompleteAddress = "Test";
            result.City = "Manila";
            result.State = "Manila";
            result.Country = "Philippines";
            result.M5vm8 = "test@M5vm8.com";

            return result;
        }

        public async Task<SocialMediaModel> GetSocialMedia()
        {
            SocialMediaModel result = new();

            result.Instagram = "beverlycheng";
            result.Youtube = "Test";
            result.Tiktok = "Test";
            result.Blog = "Test";
            result.Twitter = "Test";
            result.Facebook = "Test";

            return result;
        }
        public async Task<ContactInformationModel> GetContactInformation()
        {
            ContactInformationModel result = new();

            result.PhoneNumber = 123123123;
            result.Email = "Test";

            return result;
        }

        public async Task<ManualMeasurementModel> GetManualMeaseurement()
        {
            ManualMeasurementModel result = new();

            result.Units = 123123123;
            result.Hip = 11;
            result.Bust = 12;
            result.Waist = 13;
            result.BraSize = "XS";
            result.BraCupSize = "XS";
            result.Height = 135;
            result.HeightUnits = "cm";
            result.Weight = 60;
            result.weightUnits = "kg";

            return result;
        }
    }
}

