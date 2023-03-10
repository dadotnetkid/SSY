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
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes
{

    public class RejectionNoteService
    {
        public RejectionNoteService(IJSRuntime js,
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

        public async Task<GetAllRejectionNoteOutputModel> GetAllRejectionV2(string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/rejection-notes";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            // request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllRejectionNoteOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseStream);
                var data = JsonSerializer.Deserialize<GetAllRejectionNoteOutputModel>(responseStream);
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

        public async Task<CreateRejectionNoteOutputModel> CreateRejectionNote(CreateRejectionNoteModel input)
        {
            CreateRejectionNoteModel createRejectionNoteModel = new()
            {
                RootId = input.RootId,
                ProductId = input.ProductId,
                ChildProductId = input.ChildProductId,
                Section = input.Section,
                SectionId = input.SectionId,
                Side = input.Side,
                Notes = input.Notes,
                FilePath = input.FilePath,
                User = input.User,
                UserId = input.UserId
            };

            var json = JsonSerializer.Serialize(createRejectionNoteModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/rejection-notes";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            CreateRejectionNoteOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = JsonSerializer.Deserialize<CreateRejectionNoteOutputModel>(responseStream);
                result = data;
                await _js.InvokeVoidAsync("defaultMessage", "success", "Reply Sucess!", "");
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
}