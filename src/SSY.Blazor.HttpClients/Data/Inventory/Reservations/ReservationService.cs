using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations
{
    public class ReservationService
    {
        public ReservationService(IJSRuntime js,
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


        public async Task<GetAllReservationOutputModel> GetAllReservation(string? keyword, Guid? materialId, Guid? collectionId, int? maxResultCount)
        {
            GetAllReservationOutputModel result = new();

            var url = $"{_configuration["App:ServerRootAddress"]}/Reservation/GetAll?MaxResultCount=100&";

            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (materialId != null)
                url += "MaterialId=" + HttpUtility.UrlEncode("" + materialId) + "&";
            if (collectionId != null)
                url += "CollectionId=" + HttpUtility.UrlEncode("" + collectionId) + "&";
            if (maxResultCount != null)
                url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllReservationOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Reservation Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetReservationOutputModel> GetReservation(Guid id)
        {
            GetReservationOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/Reservation/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetReservationOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Reservation Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task CreateMaterialReservation(CreateRollReservationModel reservation)
        {
            var json = JsonSerializer.Serialize(reservation);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Reservation/CreateRollReservation";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Reservation Success!", "");
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

        public async Task CreateSubMaterialReservation(CreateSubMaterialReservationModel reservation)
        {
            var json = JsonSerializer.Serialize(reservation);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Reservation/CreateSubMaterialReservation";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Reservation Success!", "");
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

        public async Task DeleteMaterialReservation(Guid id)
        {
            DeleteReservationModel reservation = new() { Id = id };

            var json = JsonSerializer.Serialize(reservation);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/ReservationDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");

                //var data = await JsonSerializer.DeserializeAsync<GetReservationOutputModel>(responseStream);
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

        public async Task DeleteSubMaterialReservation(Guid id)
        {
            DeleteReservationModel reservation = new() { Id = id };

            var json = JsonSerializer.Serialize(reservation);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/ReservationDelete";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");

                //var data = await JsonSerializer.DeserializeAsync<GetReservationOutputModel>(responseStream);
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

        public async Task<bool> DeleteMaterialReservationList(List<Guid> input)
        {
            var result = false;
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(JsonSerializer.Serialize(json));

            // var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"{_configuration["App:ServerRootAddress"]}/Reservation/DeleteRollReservationList?";
            foreach (var id in input)
            {
                url += "input=" + HttpUtility.UrlEncode("" + id) + "&";
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                result = true;
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");

                //var data = await JsonSerializer.DeserializeAsync<GetReservationOutputModel>(responseStream);
                //result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                result = false;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Roll Reservations Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }
    }
}

