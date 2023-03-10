//using System;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Web;
//using Microsoft.AspNetCore.Components;
//using Microsoft.Extensions.Configuration;
//using Microsoft.JSInterop;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using SSY.Blazor.HttpClients.Data.Administration.Users.Model;

//namespace SSY.Blazor.HttpClients.Data.Administration.Users
//{

//    public class UserService
//    {
//        public UserService(IJSRuntime js,
//        IHttpClientFactory ClientFactory,
//        NavigationManager NavigationManager,
//        IConfiguration Configuration,
//        ProtectedLocalStorage LocalStorage)
//        {
//            _js = js;
//            _clientFactory = ClientFactory;
//            _navigationManager = NavigationManager;
//            _configuration = Configuration;
//            _localStorage = LocalStorage;
//        }

//        #region Injects

//        private readonly IJSRuntime _js;
//        private readonly IHttpClientFactory _clientFactory;
//        private readonly NavigationManager _navigationManager;
//        private readonly IConfiguration _configuration;

//        #endregion

//        public async Task<GetAllUserOutputModel> GetAllUser(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
//        {
//            var url = $"{_configuration["App:ServerRootAddress"]}/User/GetAll?";
//            if (keyword != null)
//                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
//            if (sorting != null)
//                url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
//            if (skipCount != null)
//                url += "SkipCount=" + HttpUtility.UrlEncode("" + skipCount) + "&";
//            if (maxResultCount != null)
//                url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount) + "&";
//            url = url.Replace("/[?&]$/", "");


//            var request = new HttpRequestMessage(HttpMethod.Get, url);
//            request.Headers.Add("Accept", "*/* ");
//            request.Headers.Add("User-Agent", "Inventory");

//            var client = _clientFactory.CreateClient();
//            var response = await client.SendAsync(request);

//            GetAllUserOutputModel result = new();

//            if (response.IsSuccessStatusCode)
//            {
//                using var responseStream = await response.Content.ReadAsStreamAsync();

//                var data = await JsonSerializer.DeserializeAsync<GetAllUserOutputModel>(responseStream);
//                result = data;
//            }
//            else
//            {
//                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All User Failed!", "");
//                Console.WriteLine(response.Content.ToString());
//            }

//            return result;
//        }

//        public async Task<GetUserOutputModel> GetUser(long? id)
//        {
//            var url = $"{_configuration["App:ServerRootAddress"]}/User/Get?Id={id}";

//            var request = new HttpRequestMessage(HttpMethod.Get, url);
//            request.Headers.Add("Accept", "*/* ");
//            request.Headers.Add("User-Agent", "Inventory");

//            var client = _clientFactory.CreateClient();
//            var response = await client.SendAsync(request);

//            GetUserOutputModel result = new();

//            if (response.IsSuccessStatusCode)
//            {
//                using var responseStream = await response.Content.ReadAsStreamAsync();

//                var data = await JsonSerializer.DeserializeAsync<GetUserOutputModel>(responseStream);
//                result = data;
//            }
//            else
//            {
//                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All User Failed!", "");
//                Console.WriteLine(response.Content.ToString());
//            }

//            return result;
//        }

//        public async Task CheckAdminCredential()
//        {
//            var session = await _localStorage.GetAsync<UserSession>("userSession");
//            if (!session.Success)
//            {
//                _navigationManager.NavigateTo("/", true);
//                return;
//            }
//            if (!session.Value.IsAdmin)
//            {
//                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "error", "Invalid User Access!", "", "/influencer/dashboard");
//            }
//        }

//        public async Task CheckUserCredential()
//        {
//            var session = await _localStorage.GetAsync<UserSession>("userSession");

//            if (!session.Success)
//            {
//                _navigationManager.NavigateTo("/", true);
//                return;
//            }

//            if (session.Value.IsAdmin)
//            {
//                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "error", "Invalid User Access!", "", "/dashboard");
//            }
//        }


//    }
//}

