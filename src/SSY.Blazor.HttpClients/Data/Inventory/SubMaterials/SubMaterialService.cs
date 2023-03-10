using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Locations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials
{
    public class SubMaterialService
    {
        public SubMaterialService(IJSRuntime js,
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


        public async Task<GetAllSubMaterialOutputModel> GetAllSubMaterial(int? categoryId, string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetAll?";
            if (categoryId != null)
                url += "CategoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";
            if (sorting != null)
                url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
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

            GetAllSubMaterialOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllSubMaterialOutputModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", "");
                Console.WriteLine(JsonSerializer.Serialize(data.Message));
            }

            return result;
        }

        public async Task<GetSubMaterialOutputModel> GetSubMaterial(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/Get?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetSubMaterialOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetSubMaterialOutputModel>(responseStream);
                result = data;
            }
            else
            {
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Material Failed!", "");
                Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
            }

            return result;
        }

        public async Task<List<SubMaterialModel>> GetSubMaterialSearch(int categoryId, string? typeId, string? status)
        {
            List<SubMaterialModel> result = new();

            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetAll?";

            url += "CategoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";
            url += "MaxResultCount=" + HttpUtility.UrlEncode("" + 10) + "&";

            if (typeId != null && typeId != "0" && typeId != "all")
                url += "TypeId=" + HttpUtility.UrlEncode("" + typeId) + "&";
            if (status != null && status != "0" && status != "all")
                url += "Status=" + HttpUtility.UrlEncode("" + status) + "&";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllSubMaterialOutputModel>(responseStream);
                result = data.Result.Items;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All SubMaterial Search Failed!", "");
                Console.WriteLine(JsonSerializer.Serialize(data.Message));
            }

            return result;
        }

        public async Task CreateSubMaterial(SubMaterialModel subMaterial, int CategoryId, string Module)
        {
            CreateSubMaterialModel createSubMaterialDto = new()
            {
                TenantId = subMaterial.TenantId,
                IsActive = subMaterial.IsActive,
                Image = subMaterial.Image,
                CategoryId = CategoryId,
                Name = subMaterial.Name,
                TypeId = (int)subMaterial.TypeId,
                ColorId = (int)subMaterial.ColorId,
                Weight = subMaterial.Weight,
                WeightUnitId = (int)subMaterial.WeightUnitId,

                TotalCount = subMaterial.TotalCount,
                UnitOfMeasurementId = (int)subMaterial.UnitOfMeasurementId,
                MinimumStockLevel = subMaterial.MinimumStockLevel,
                IncomingCount = subMaterial.IncomingCount,
                ReservedCount = subMaterial.ReservedCount,
                AvailableCount = subMaterial.TotalCount,
                UsedCount = subMaterial.UsedCount,
                OnHandCount = subMaterial.TotalCount - subMaterial.IncomingCount,

                //LocationId = subMaterial.LocationId,
                Location = new CreateLocationModel()
                {
                    TenantId = subMaterial.TenantId,
                    BuildingWarehouse = subMaterial.Location.BuildingWarehouse,
                    Room = subMaterial.Location.Room,
                    Rack = subMaterial.Location.Rack
                },
                CompanyId = subMaterial.Company.Id,
                PurchaseDetail = new CreatePurchaseDetailModel()
                {
                    TenantId = subMaterial.TenantId,
                    IsActive = subMaterial.IsActive,
                    Price = subMaterial.PurchaseDetail.Price,
                    Count = subMaterial.PurchaseDetail.Count,
                    CurrencyId = subMaterial.PurchaseDetail.CurrencyId,
                    UnitOfMeasurementId = subMaterial.PurchaseDetail.UnitOfMeasurementId,
                    Upcharge = subMaterial.PurchaseDetail.Upcharge,
                    UpchargeTypeId = subMaterial.PurchaseDetail.UpchargeTypeId,
                    UpchargePrice = subMaterial.PurchaseDetail.UpchargePrice,
                    UpchargePercentage = subMaterial.PurchaseDetail.UpchargePercentage,
                    PricingTypeId = subMaterial.PurchaseDetail.PricingTypeId,
                    BelowMinimumOrderQuantityCount = subMaterial.PurchaseDetail.BelowMinimumOrderQuantityCount,
                    BelowMinimumOrderQuantityCurrencyId = subMaterial.PurchaseDetail.BelowMinimumOrderQuantityCurrencyId,
                    BelowMinmumOrderQuantityUnitOfMeasurementId = subMaterial.PurchaseDetail.BelowMinmumOrderQuantityUnitOfMeasurementId,
                    GeneralInformationMinimumOrderQuantity = subMaterial.PurchaseDetail.GeneralInformationMinimumOrderQuantity,
                    GeneralInformationMinimumColorQuantity = subMaterial.PurchaseDetail.GeneralInformationMinimumColorQuantity,
                    GeneralInformationUnitOfMeasurementId = subMaterial.PurchaseDetail.GeneralInformationUnitOfMeasurementId,
                    LeadTime = subMaterial.PurchaseDetail.LeadTime,
                    ShippingTimeByAir = subMaterial.PurchaseDetail.ShippingTimeByAir,
                    ShippingTimeBySea = subMaterial.PurchaseDetail.ShippingTimeBySea
                }
            };

            var json = JsonSerializer.Serialize(createSubMaterialDto);

            Console.WriteLine("json");
            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/Create";

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

                var data = await JsonSerializer.DeserializeAsync<GetSubMaterialOutputModel>(responseStream);
                if (Module == "Trims and Accessories")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", "/inventory/trimsandaccessories");
                }
                else if (Module == "Packaging")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", "/inventory/packaging");
                }
                else if (Module == "Others")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added", "", "/inventory/others");
                }
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task UpdateSubMaterial(SubMaterialModel subMaterial, int CategoryId, string Module)
        {

            UpdateSubMaterialModel updateSubMaterialDto = new()
            {
                Id = subMaterial.Id,
                TenantId = subMaterial.TenantId,
                IsActive = subMaterial.IsActive,
                Image = subMaterial.Image,
                CategoryId = CategoryId,
                Name = subMaterial.Name,
                typeId = (int)subMaterial.TypeId,
                ColorId = (int)subMaterial.ColorId,
                Weight = subMaterial.Weight,
                WeightUnitId = (int)subMaterial.WeightUnitId,

                TotalCount = subMaterial.TotalCount,
                UnitOfMeasurementId = (int)subMaterial.UnitOfMeasurementId,
                MinimumStockLevel = subMaterial.MinimumStockLevel,
                IncomingCount = (double)subMaterial.IncomingCount,
                ReservedCount = (double)subMaterial.ReservedCount,
                AvailableCount = subMaterial.TotalCount - subMaterial.ReservedCount,
                UsedCount = (double)subMaterial.UsedCount,
                OnHandCount = (double)(subMaterial.TotalCount - subMaterial.IncomingCount),

                // LocationId = subMaterial.LocationId,
                Location = new UpdateLocationModel()
                {
                    Id = subMaterial.Location.Id,
                    TenantId = subMaterial.Location.TenantId,
                    BuildingWarehouse = subMaterial.Location.BuildingWarehouse,
                    Room = subMaterial.Location.Room,
                    Rack = subMaterial.Location.Rack
                },
                CompanyId = subMaterial.Company.Id,
                PurchaseDetail = new UpdatePurchaseDetailModel()
                {
                    Id = subMaterial.PurchaseDetail.Id,
                    TenantId = subMaterial.PurchaseDetail.TenantId,
                    IsActive = subMaterial.PurchaseDetail.IsActive,
                    Price = subMaterial.PurchaseDetail.Price,
                    Count = subMaterial.PurchaseDetail.Count,
                    CurrencyId = subMaterial.PurchaseDetail.CurrencyId,
                    UnitOfMeasurementId = subMaterial.PurchaseDetail.UnitOfMeasurementId,
                    Upcharge = subMaterial.PurchaseDetail.Upcharge,
                    UpchargeTypeId = subMaterial.PurchaseDetail.UpchargeTypeId,
                    UpchargePrice = subMaterial.PurchaseDetail.UpchargePrice,
                    UpchargePercentage = subMaterial.PurchaseDetail.UpchargePercentage,
                    PricingTypeId = subMaterial.PurchaseDetail.PricingTypeId,
                    BelowMinimumOrderQuantityCount = subMaterial.PurchaseDetail.BelowMinimumOrderQuantityCount,
                    BelowMinimumOrderQuantityCurrencyId = subMaterial.PurchaseDetail.BelowMinimumOrderQuantityCurrencyId,
                    BelowMinmumOrderQuantityUnitOfMeasurementId = subMaterial.PurchaseDetail.BelowMinmumOrderQuantityUnitOfMeasurementId,
                    GeneralInformationMinimumOrderQuantity = subMaterial.PurchaseDetail.GeneralInformationMinimumOrderQuantity,
                    GeneralInformationMinimumColorQuantity = subMaterial.PurchaseDetail.GeneralInformationMinimumColorQuantity,
                    GeneralInformationUnitOfMeasurementId = subMaterial.PurchaseDetail.GeneralInformationUnitOfMeasurementId,
                    LeadTime = subMaterial.PurchaseDetail.LeadTime,
                    ShippingTimeByAir = subMaterial.PurchaseDetail.ShippingTimeByAir,
                    ShippingTimeBySea = subMaterial.PurchaseDetail.ShippingTimeBySea
                }
            };

            var json = JsonSerializer.Serialize(updateSubMaterialDto);
            Console.WriteLine("blahblahsubmaterial");
            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/Update";

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

                var data = await JsonSerializer.DeserializeAsync<GetSubMaterialOutputModel>(responseStream);
                if (Module == "Trims and Accessories")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/trimsandaccessories/");
                }
                else if (Module == "Packaging")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/packaging/");
                }
                else if (Module == "Others")
                {
                    await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/others/");
                }
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task<GraphSubMaterialModel> GetTopUsedSubMaterial(int categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetTopUsedMaterial?categoryId={categoryId}";


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphSubMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphSubMaterialModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GraphSubMaterialModel> GetSubMaterialColor(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetSubMaterialPerColor?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphSubMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphSubMaterialModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GraphSubMaterialModel> GetSubMaterialPerMaterialTypes(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetSubMaterialPerMaterialTypes?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphSubMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphSubMaterialModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GraphSubMaterialModel> GetSubMaterialPerMaterialType(int categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetMaterialPerType?categoryId={categoryId}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphSubMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphSubMaterialModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task<GraphSubMaterialModel> GetSubMaterialCountPerInfluencerAndMaterialType(int categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetMaterialCountPerInfluencerAndMaterialType?categoryId={categoryId}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphSubMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphSubMaterialModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task GenerateExcelExport(string FileName, byte[] data, string type = "application/octet-stream")
        {
            await _js.InvokeAsync<object>("JSInteropExt.SaveAsFilex", FileName, type, Convert.ToBase64String(data));

        }

        public async Task BulkCreateMaterial(IEnumerable<CreateSubMaterialModel> input)
        {

            // var batches = Math.Ceiling(Convert.ToDouble(input.Count()/5000));
            var batches = Math.Ceiling((double)(input.Count() / 5000));
            var totalcount = input.Count();
            // var batch 
            var json = JsonSerializer.Serialize(input);
            bool isSuccess = false;

            //Console.WriteLine(json);
            //return;

            // System.Console.WriteLine(json);
            // return;
            if (batches <= 1)
            {
                isSuccess = await MassUpload(input, 1);
            }
            else
            {
                for (int i = 0; i < batches; i++)
                {
                    var submaterials = await GetBatch(input, i);
                    isSuccess = await MassUpload(submaterials, i++);
                }
            }

            if (isSuccess) await _js.InvokeVoidAsync("defaultMessage", "success", "Mass Upload Success!", "");

        }

        private async Task<IEnumerable<CreateSubMaterialModel>> GetBatch(IEnumerable<CreateSubMaterialModel> input, int batch)
        {
            return input.Skip(batch * 5000).Take(5000);
        }

        private async Task<bool> MassUpload(IEnumerable<CreateSubMaterialModel> input, int batch)
        {
            var json = JsonSerializer.Serialize(input);


            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/MassUpload";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            SubMaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                // using var responseStream = await response.Content.ReadAsStreamAsync();

                // var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                // material = data.Result;

                // await _js.InvokeVoidAsync("defaultMessage", "success", "Mass Upload Success!", "");
                return true;
            }
            else
            {
                // await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", "");
                // Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", $"Adding Failed!", $"{data.Error.Message}/n total added items {batch-- * 5000}");
                Console.WriteLine(data.Error.Message);
                return false;
            }
        }

        public async Task<bool> MassIssuanceAsync(IEnumerable<SubMaterialIssuanceModel> input)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/MassIssuance";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            // MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                // using var responseStream = await response.Content.ReadAsStreamAsync();

                // var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                // material = data.Result;

                await _js.InvokeVoidAsync("defaultMessage", "success", "Mass Issuance Success!", "");
                return true;
            }
            else
            {
                // await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", "");
                // Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
                using var responseStream = await response.Content.ReadAsStreamAsync();
                // var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Mass Issuance Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
                return false;
            }
        }


        public async Task<GetAllAdjustmentListModel> GetAllAdjustment(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/GetAllAdjustment?";

            url += "subMaterialId=" + HttpUtility.UrlEncode("" + id) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllAdjustmentListModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllAdjustmentListModel>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Failed!", "");
                Console.WriteLine(JsonSerializer.Serialize(data.Message));
            }

            return result;
        }

        public async Task<bool> MassAdjustmentAsync(IEnumerable<SubMaterialAdjustmentModel> input)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ServerRootAddress"]}/SubMaterial/MassAdjustment";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                // using var responseStream = await response.Content.ReadAsStreamAsync();

                // var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                // material = data.Result;

                await _js.InvokeVoidAsync("defaultMessage", "success", "Mass Adjustment Success!", "");
                return true;
            }
            else
            {
                // await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", "");
                // Console.WriteLine(JsonSerializer.Serialize(response.RequestMessage));
                using var responseStream = await response.Content.ReadAsStreamAsync();
                // var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Mass Adjustment Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
                return false;
            }
        }

    }
}

