using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model;

namespace SSY.Blazor.HttpClients.Data.Administration.UserDetails
{
    public class UserDetailService
    {
        public UserDetailService(IJSRuntime js,
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


        public async Task<GetAllUserDetailOutputModel> GetAllUser(string? keyword, long? userId, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/GetAll?";
            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (userId != null)
                url += "UserId=" + HttpUtility.UrlEncode("" + userId) + "&";
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

            GetAllUserDetailOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllUserDetailOutputModel>(responseStream);
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

        public async Task<GetAllUserDetailCCOutputModel> GetAllUserCC(string? roleNames, string? keyword, long? userId, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/GetAll?";
            if (roleNames != null)
                url += "RoleNames=" + HttpUtility.UrlEncode("" + roleNames) + "&";
            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
            if (userId != null)
                url += "UserId=" + HttpUtility.UrlEncode("" + userId) + "&";
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

            GetAllUserDetailCCOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllUserDetailCCOutputModel>(responseStream);
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

        public async Task<GetUserDetailOutputModel> GetUserDetail(Guid id)
        {
            GetUserDetailOutputModel result = new();
            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetUserDetailOutputModel>(responseStream);
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

        public async Task UpdateUserDetails(UserDetailModel inputUpdate)
        {


            UpdateUserDetailModel updateUserDetail = new()
            {
                Id = inputUpdate.Id,
                UserId = inputUpdate.UserId,
                Name = inputUpdate.Name,
                Surname = inputUpdate.Surname,
                EmailAddress = inputUpdate.EmailAddress,
                RoleNames = inputUpdate.RoleNames,
                Password = inputUpdate.Password,
                CompanyId = inputUpdate.CompanyId,
                PhoneNumber = inputUpdate.PhoneNumber,
                Position = inputUpdate.Position,
                Remarks = inputUpdate.Remarks,
                ProductQuantityForecast = inputUpdate.ProductQuantityForecast,
                Collections = inputUpdate.Collections
            };

            var json = JsonSerializer.Serialize(updateUserDetail);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/Update";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            UserDetailModel userDetailModel = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetUserDetailOutputModel>(responseStream);
                userDetailModel = data.Result;
                await _js.InvokeVoidAsync("defaultMessage", "success", "Comment Update Success", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }


        public async Task<CreateOutputUserDetailModel> CreateUserDetail(UserDetailModel input)
        {

            CreateOutputUserDetailModel results = new();

            CreateUserDetailModel userDetailModel = new()
            {
                TenantId = input.TenantId,
                IsActive = input.IsActive,
                Name = input.Name,
                Surname = input.Surname,
                EmailAddress = input.EmailAddress,
                RoleNames = input.RoleNames,
                Password = input.Password,
                UserId = input.UserId,
                CompanyId = input.CompanyId,
                PhoneNumber = input.PhoneNumber,
                Position = input.Position,
                Remarks = input.Remarks,
                ProductQuantityForecast = input.ProductQuantityForecast,
                Collections = input.Collections
            };

            var json = JsonSerializer.Serialize(userDetailModel);

            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/Create";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var userDetailResponseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<CreateOutputUserDetailModel>(userDetailResponseStream);
                results = data;
                await _js.InvokeVoidAsync("defaultMessage", "success", "Create User Success", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Create User Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

            return results;
        }

        public async Task DeleteUserDetail(Guid id)
        {
            DeleteUserDetailModel input = new() { Id = id };

            var json = JsonSerializer.Serialize(input);
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_configuration["App:ServerRootAddress"]}/UserDetail/Delete?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetUserDetailOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
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
}

