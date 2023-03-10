using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;


namespace SSY.Blazor.HttpClients.Data.Inventory.Companies
{
    public class CompanyService
    {
        public CompanyService(IJSRuntime js,
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
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Company Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GetCompanyOutputModel> GetCompany(int id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Company/Get?Id={id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetCompanyOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetCompanyOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Company Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task CreateCompanyAsync(CompanyModel companyModel)
        {
            List<CreateContactPersonsModel> contactPersons = new();
            companyModel.ContactPersons.ForEach(x =>
            {
                contactPersons.Add(new()
                {

                    TenantId = x.TenantId,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    Position = x.Position,
                    Email = x.Email,
                    MobileNumber = x.MobileNumber,
                    Telephone = x.Telephone
                });
            });

            CreateCompanyModel createCompanyModel = new()
            {
                Id = companyModel.Id,
                TenantId = 1,
                IsActive = true,
                ShortCode = companyModel.ShortCode,
                Name = companyModel.Name,
                Website = companyModel.Website,
                Address1 = companyModel.Address1,
                Address2 = companyModel.Address2,
                Country = companyModel.Country,
                Province = companyModel.Province,
                City = companyModel.City,
                ZipCode = companyModel.ZipCode,
                BankName = companyModel.BankName,
                AccountNumber = companyModel.AccountNumber,
                AccountName = companyModel.AccountName,
                Swift = companyModel.Swift,
                Address = companyModel.Address,
                IsExcessSupplier = companyModel.IsExcessSupplier,
                CompanyTypeIds = companyModel.CompanyTypeIds,
                CompanyExcessReminderIds = companyModel.CompanyExcessReminderIds,
                MaterialTypeIds = companyModel.MaterialTypeIds,
                ContactPersons = contactPersons
            };

            var json = JsonSerializer.Serialize(createCompanyModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Company/Create";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Create Success!", "", $"/inventory/supplier");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Create Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task UpdateCompany(CompanyModel companyModel)
        {
            List<UpdateContactPersonsModel> contactPersons = new();

            companyModel.ContactPersons.ForEach(x =>
            {
                contactPersons.Add(new()
                {
                    Id = x.ContactPersonId,
                    TenantId = x.TenantId,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    Position = x.Position,
                    Email = x.Email,
                    MobileNumber = x.MobileNumber,
                    Telephone = x.Telephone
                });
            });

            UpdateCompanyModel updateCompanyModel = new()
            {
                Id = companyModel.Id,
                TenantId = companyModel.TenantId,
                IsActive = companyModel.IsActive,
                ShortCode = companyModel.ShortCode,
                Name = companyModel.Name,
                Website = companyModel.Website,
                Address1 = companyModel.Address1,
                Address2 = companyModel.Address2,
                Country = companyModel.Country,
                Province = companyModel.Province,
                City = companyModel.City,
                ZipCode = companyModel.ZipCode,
                BankName = companyModel.BankName,
                AccountNumber = companyModel.AccountNumber,
                AccountName = companyModel.AccountName,
                Swift = companyModel.Swift,
                Address = companyModel.Address,
                IsExcessSupplier = companyModel.IsExcessSupplier,
                CompanyTypeIds = companyModel.CompanyTypeIds,
                CompanyExcessReminderIds = companyModel.CompanyExcessReminderIds,
                MaterialTypeIds = companyModel.MaterialTypeIds,
                ContactPersons = contactPersons
            };

            var json = JsonSerializer.Serialize(updateCompanyModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Company/Update";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/supplier/{companyModel.Id}");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Company/Delete?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Success!", "");
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Delete Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }
        }

        public async Task GenerateExcelExport(string FileName, byte[] data, string type = "application/octet-stream")
        {
            await _js.InvokeAsync<object>("JSInteropExt.SaveAsFilex", FileName, type, Convert.ToBase64String(data));
        }

    }
}

