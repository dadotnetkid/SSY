using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Administration.Roles.Model;

namespace SSY.Blazor.HttpClients.Data.Administration.Roles
{
    public class RoleService
    {
        public RoleService(IJSRuntime js,
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

        public async Task<GetAllRoleOutputModel> GetAllRole(string? keyword, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Role/GetAll?";
            if (keyword != null)
                url += "Keyword=" + HttpUtility.UrlEncode("" + keyword) + "&";
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

            GetAllRoleOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllRoleOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Supplier Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }


        // public async Task<GetSupplierOutputModel> GetSupplier(Guid id)
        // {
        //     var url = $"{_configuration["App:ServerRootAddress"]}/Supplier/Get?Id={id}";
        //     var request = new HttpRequestMessage(HttpMethod.Get, url);
        //     request.Headers.Add("Accept", "*/* ");
        //     request.Headers.Add("User-Agent", "Inventory");

        //     var client = _clientFactory.CreateClient();
        //     var response = await client.SendAsync(request);

        //     GetSupplierOutputModel result = new();

        //     if (response.IsSuccessStatusCode)
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();

        //         var data = await JsonSerializer.DeserializeAsync<GetSupplierOutputModel>(responseStream);
        //         result = data;
        //     }
        //     else
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
        //         //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Supplier Failed!", $"{data.Message}");
        //         System.Console.WriteLine(data.Message);
        //     }

        //     return result;
        // }


        // public async Task UpdateSupplier(SupplierModel suppplierModel)
        // {
        //     var contactPerson = suppplierModel.ContactPersons;

        //     UpdateSupplierModel updateSupplier = new()
        //     {
        //         Id = suppplierModel.Id,
        //         TenantId = suppplierModel.TenantId,
        //         IsActive = suppplierModel.IsActive,
        //         AccountName = suppplierModel.AccountName,
        //         AccountNumber = suppplierModel.AccountNumber,
        //         Address = suppplierModel.Address,
        //         Address1 = suppplierModel.Address1,
        //         Address2 = suppplierModel.Address2,
        //         ShortCode = suppplierModel.ShortCode,
        //         BankName = suppplierModel.BankName,
        //         City = suppplierModel.City,
        //         Code = suppplierModel.Code,
        //         ContactPersons = contactPerson.Select(x => new UpdateContactPersonModel()
        //         {
        //             Id = x.Id,
        //             TenantId = x.TenantId,
        //             IsActive = x.IsActive,

        //             Name = x.Name,
        //             Position = x.Position,
        //             Email = x.Email,
        //             MobileNumber = x.MobileNumber,
        //             Telephone = x.Telephone,
        //             IsDeleted = x.IsDeleted,
        //             CompanyId = suppplierModel.Id
        //         }
        //         ).ToList(),
        //         ContactPersonContactEmail = suppplierModel.ContactPersonContactEmail,
        //         ContactPersonName = suppplierModel.ContactPersonName,
        //         ContactPersonNumber = suppplierModel.ContactPersonNumber,
        //         Country = suppplierModel.Country,
        //         Name = suppplierModel.Name,
        //         Province = suppplierModel.Province,
        //         Swift = suppplierModel.Swift,
        //         Website = suppplierModel.Website,
        //         ZipCode = suppplierModel.ZipCode
        //     };

        //     var json = JsonSerializer.Serialize(updateSupplier);

        //     System.Console.WriteLine(json);

        //     var url = $"{_configuration["App:ServerRootAddress"]}/Supplier/Update";

        //     var content = new StringContent(json, Encoding.UTF8, "application/json");
        //     var request = new HttpRequestMessage(HttpMethod.Put, url);
        //     request.Headers.Add("Accept", "*/*");
        //     request.Headers.Add("User-Agent", "Inventory");
        //     request.Content = content;

        //     var client = _clientFactory.CreateClient();
        //     var response = await client.SendAsync(request);

        //     SupplierModel supplier = new();

        //     if (response.IsSuccessStatusCode)
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();

        //         var data = await JsonSerializer.DeserializeAsync<GetSupplierOutputModel>(responseStream);
        //         supplier = data.Result;
        //         await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/supplier/{supplier.Id}");

        //     }
        //     else
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
        //         await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
        //         System.Console.WriteLine(data.Message);
        //     }
        // }


        // public async Task GenerateExcelExport(string FileName, byte[] data, string type = "application/octet-stream")
        // {
        //     await _js.InvokeAsync<object>("JSInteropExt.SaveAsFilex", FileName, type, Convert.ToBase64String(data));

        // }

    }
}

