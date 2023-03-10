using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials
{
    public class MaterialService
    {
        public MaterialService(IJSRuntime js,
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


        public async Task<GetAllMaterialOutputModel> GetAllMaterial(int? categoryId, int? colorId, string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetAll?";

            if (categoryId != null)
                url += "CategoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";
            if (colorId != null)
                url += "ColorId=" + HttpUtility.UrlEncode("" + colorId) + "&";
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

            GetAllMaterialOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllMaterialOutputModel>(responseStream);
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

        public async Task<GetMaterialOutputModel> GetMaterial(Guid id)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/Get?Id={id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetMaterialOutputModel material = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                material = data;

                material.Result.Accountability = material.Result.Accountability ?? new();
                material.Result.PurchaseDetail = material.Result.PurchaseDetail ?? new();

                // Material AssignmentIds

                if (material.Result.AssignmentIds != null)
                {
                    var assignmentIds = JsonSerializer.Deserialize<List<int>>(material.Result.AssignmentIds);
                    material.Result.AssignmentList = assignmentIds != null ? assignmentIds : new();
                }

                // CompositionAndConstuction - HandFeelIds

                if (material.Result.CompositionAndConstruction.HandFeelIds != null)
                {
                    var handfeelIds = JsonSerializer.Deserialize<List<int>>(material.Result.CompositionAndConstruction.HandFeelIds);
                    material.Result.CompositionAndConstruction.HandFeelIdList = handfeelIds != null ? handfeelIds : new();
                }

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get Material Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return material;
        }

        public async Task<List<MaterialModel>> GetMaterialSearch(int categoryId, string? typeId, string? status, string? assignmentId)
        {
            List<MaterialModel> result = new();

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetAll?";

            url += "CategoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";
            url += "MaxResultCount=" + HttpUtility.UrlEncode("" + 10) + "&";

            if (typeId != null && typeId != "0" && typeId != "all")
                url += "TypeId=" + HttpUtility.UrlEncode("" + typeId) + "&";
            if (status != null && status != "0" && status != "all")
                url += "Status=" + HttpUtility.UrlEncode("" + status) + "&";
            if (assignmentId != null && assignmentId != "0" && assignmentId != "all")
                url += "AssignmentId=" + HttpUtility.UrlEncode("" + assignmentId) + "&";

            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetAllMaterialOutputModel>(responseStream);
                result = data.Result.Items;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All Material Search Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }

            return result;
        }

        public async Task BulkCreateMaterial(IEnumerable<MaterialModel> input)
        {

            // var batches = Math.Ceiling(Convert.ToDouble(input.Count()/5000));
            var batches = Math.Ceiling((double)(input.Count() / 5000));
            var totalcount = input.Count();
            // var batch 
            var json = JsonSerializer.Serialize(input);
            bool isSuccess = false;

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
                    var materials = await GetBatch(input, i);
                    isSuccess = await MassUpload(materials, i++);
                }
            }

            if (isSuccess) await _js.InvokeVoidAsync("defaultMessage", "success", "Mass Upload Success!", "");

        }

        private async Task<IEnumerable<MaterialModel>> GetBatch(IEnumerable<MaterialModel> input, int batch)
        {
            return input.Skip(batch * 5000).Take(5000);
        }

        private async Task<bool> MassUpload(IEnumerable<MaterialModel> input, int batch)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/MassUpload";

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

        public async Task<bool> MassIssuanceAsync(IEnumerable<MaterialIssuanceModel> input)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/MassIssuance";

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

        public async Task<bool> MassAdjustmentAsync(IEnumerable<MaterialAdjustmentModel> input)
        {
            var json = JsonSerializer.Serialize(input);

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/MassAdjustment";

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

        public async Task UpdateMaterial(MaterialModel MaterialModel)
        {

            UpdateMaterialModel updateMaterialDto = new()
            {
                Id = MaterialModel.Id,
                TenantId = MaterialModel.TenantId,
                IsActive = MaterialModel.IsActive,

                AssignmentList = MaterialModel.AssignmentList,
                Image = MaterialModel.Image,
                CategoryId = MaterialModel.CategoryId,
                TypeId = (int)MaterialModel.TypeId,
                ItemCode = MaterialModel.ItemCode,
                ColorCode = MaterialModel.ColorCode,
                ColorId = (int)MaterialModel.ColorId,
                Pantone = MaterialModel.Pantone,
                Weight = (double)MaterialModel.Weight,
                WeightUnitId = (int)MaterialModel.WeightUnitId,
                CuttableWidth = MaterialModel.CuttableWidth,

                IncomingCount = MaterialModel.RollsAndLocations.Sum(x => x.IncomingCount),
                ReservedCount = MaterialModel.ReservedCount,
                AvailableCount = MaterialModel.RollsAndLocations.Sum(x => x.AvailableCount),
                OnHandCount = MaterialModel.RollsAndLocations.Sum(x => x.OnHandCount),
                UsedCount = MaterialModel.UsedCount,
                MinimumStockLevel = MaterialModel.MinimumStockLevel,
                TotalCount = (double)MaterialModel.RollsAndLocations.Sum(x => x.TotalCount),
                UnitOfMeasurementId = (int)MaterialModel.UnitOfMeasurementId,
                RollsAndLocations = MaterialModel.RollsAndLocations.Select(x => new UpdateRollAndLocationModel()
                {
                    Id = x.Id,
                    TenantId = x.TenantId,
                    IsActive = x.IsActive,
                    MaterialId = x.MaterialId,
                    QR = x.QR,
                    RollNumber = x.RollNumber,
                    DateAcquired = x.DateAcquired,
                    ShelfLife = x.ShelfLife,
                    TotalCount = x.TotalCount,
                    IncomingCount = x.IncomingCount,
                    ConsumeBeforeDate = x.ConsumeBeforeDate,
                    ShadingId = x.ShadingId,
                    BuildingOrWarehouse = x.BuildingOrWarehouse,
                    TRackNumber = x.TRackNumber,
                    Rack = x.Rack,
                    IsDisposal = x.IsDisposal,
                    DisposalDate = x.DisposalDate,
                    PONumber = x.PONumber
                }).ToList(),
                CompositionAndConstruction = new()
                {
                    Id = MaterialModel.CompositionAndConstruction.Id,
                    TenantId = MaterialModel.CompositionAndConstruction.TenantId,
                    IsActive = MaterialModel.CompositionAndConstruction.IsActive,
                    Content = MaterialModel.CompositionAndConstruction.Content,
                    Construction = MaterialModel.CompositionAndConstruction.Construction,
                    Gauge = MaterialModel.CompositionAndConstruction.Gauge,
                    RecycledId = (int)MaterialModel.CompositionAndConstruction.RecycledId,
                    ExcessId = (int)MaterialModel.CompositionAndConstruction.ExcessId,
                    PreparedForPrintId = (int)MaterialModel.CompositionAndConstruction.PreparedForPrintId,
                    CompressionId = MaterialModel.CompositionAndConstruction.CompressionId,
                    FabricStretchId = MaterialModel.CompositionAndConstruction.FabricStretchId,
                    CreaseId = MaterialModel.CompositionAndConstruction.CreaseId,
                    PrintRepeatId = MaterialModel.CompositionAndConstruction.PrintRepeatId,
                    HandFeelIdList = MaterialModel.CompositionAndConstruction.HandFeelIdList
                },
                CareInstructionTypeId = (int)MaterialModel.CareInstructionTypeId,
                CompanyId = MaterialModel.Company.Id,
                PurchaseDetail = new()
                {
                    Id = MaterialModel.PurchaseDetail.Id,
                    TenantId = MaterialModel.PurchaseDetail.TenantId,
                    IsActive = MaterialModel.PurchaseDetail.IsActive,
                    Price = MaterialModel.PurchaseDetail.Price,
                    Count = MaterialModel.PurchaseDetail.Count,
                    CurrencyId = MaterialModel.PurchaseDetail.CurrencyId,
                    PricingTypeId = MaterialModel.PurchaseDetail.PricingTypeId,
                    UnitOfMeasurementId = MaterialModel.PurchaseDetail.UnitOfMeasurementId,
                    Upcharge = MaterialModel.PurchaseDetail.Upcharge,
                    UpchargeTypeId = MaterialModel.PurchaseDetail.UpchargeTypeId,
                    UpchargePrice = MaterialModel.PurchaseDetail.UpchargePrice,
                    UpchargePercentage = MaterialModel.PurchaseDetail.UpchargePercentage,
                    BelowMinimumOrderQuantityCount = MaterialModel.PurchaseDetail.BelowMinimumOrderQuantityCount,
                    BelowMinimumOrderQuantityCurrencyId = MaterialModel.PurchaseDetail.BelowMinimumOrderQuantityCurrencyId,
                    BelowMinmumOrderQuantityUnitOfMeasurementId = MaterialModel.PurchaseDetail.BelowMinmumOrderQuantityUnitOfMeasurementId,
                    GeneralInformationMinimumOrderQuantity = MaterialModel.PurchaseDetail.GeneralInformationMinimumOrderQuantity,
                    GeneralInformationMinimumColorQuantity = MaterialModel.PurchaseDetail.GeneralInformationMinimumColorQuantity,
                    GeneralInformationUnitOfMeasurementId = MaterialModel.PurchaseDetail.GeneralInformationUnitOfMeasurementId,
                    LeadTime = MaterialModel.PurchaseDetail.LeadTime,
                    ShippingTimeByAir = MaterialModel.PurchaseDetail.ShippingTimeByAir,
                    ShippingTimeBySea = MaterialModel.PurchaseDetail.ShippingTimeBySea,
                    RequestId = MaterialModel.PurchaseDetail.RequestId
                }
            };


            var json = JsonSerializer.Serialize(updateMaterialDto);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/Update";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                material = data.Result;
                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Update Success!", "", $"/inventory/{material.CategoryValue.ToLower()}/detail/{material.Id}");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Message}");
                Console.WriteLine(data.Message);
            }
        }

        public async Task<Guid> CreateMaterial(MaterialModel MaterialModel)
        {

            var rollsAndLocations = MaterialModel.RollsAndLocations;

            CreateMaterialModel createMaterialModel = new()
            {
                TenantId = MaterialModel.TenantId,
                IsActive = MaterialModel.IsActive,
                Accountability = null,
                AssignmentList = MaterialModel.AssignmentList,
                Image = MaterialModel.Image,
                CategoryId = MaterialModel.CategoryId,
                TypeId = (int)MaterialModel.TypeId,
                ItemCode = MaterialModel.ItemCode,
                ColorCode = MaterialModel.ColorCode,
                ColorId = (int)MaterialModel.ColorId,
                Pantone = MaterialModel.Pantone,
                Weight = (double)MaterialModel.Weight,
                WeightUnitId = (int)MaterialModel.WeightUnitId,
                CuttableWidth = MaterialModel.CuttableWidth,

                IncomingCount = MaterialModel.RollsAndLocations.Sum(x => x.IncomingCount),
                ReservedCount = MaterialModel.ReservedCount,
                AvailableCount = MaterialModel.RollsAndLocations.Sum(x => x.AvailableCount),
                UsedCount = MaterialModel.UsedCount,
                OnHandCount = MaterialModel.RollsAndLocations.Sum(x => x.OnHandCount),
                MinimumStockLevel = MaterialModel.MinimumStockLevel,
                TotalCount = (double)MaterialModel.RollsAndLocations.Sum(x => x.TotalCount),
                UnitOfMeasurementId = (int)MaterialModel.UnitOfMeasurementId,
                RollsAndLocations = rollsAndLocations.Select(x => new CreateRollAndLocationModel()
                {
                    TenantId = x.TenantId,
                    IsActive = x.IsActive,
                    MaterialId = x.MaterialId,
                    QR = x.QR,
                    RollNumber = x.RollNumber,
                    DateAcquired = x.DateAcquired,
                    ShelfLife = x.ShelfLife,
                    TotalCount = x.TotalCount,
                    IncomingCount = x.IncomingCount,
                    ConsumeBeforeDate = x.ConsumeBeforeDate,
                    ShadingId = (int)x.ShadingId,
                    BuildingOrWarehouse = x.BuildingOrWarehouse,
                    TRackNumber = x.TRackNumber,
                    Rack = x.Rack,
                    IsDisposal = x.IsDisposal,
                    DisposalDate = x.DisposalDate,
                    PONumber = x.PONumber
                }).ToList(),
                CompositionAndConstruction = new()
                {
                    TenantId = MaterialModel.CompositionAndConstruction.TenantId,
                    IsActive = MaterialModel.CompositionAndConstruction.IsActive,
                    Content = MaterialModel.CompositionAndConstruction.Content,
                    Construction = MaterialModel.CompositionAndConstruction.Construction,
                    Gauge = MaterialModel.CompositionAndConstruction.Gauge,
                    RecycledId = (int)MaterialModel.CompositionAndConstruction.RecycledId,
                    ExcessId = (int)MaterialModel.CompositionAndConstruction.ExcessId,
                    PreparedForPrintId = (int)MaterialModel.CompositionAndConstruction.PreparedForPrintId,
                    CompressionId = MaterialModel.CompositionAndConstruction.CompressionId,
                    FabricStretchId = MaterialModel.CompositionAndConstruction.FabricStretchId,
                    CreaseId = MaterialModel.CompositionAndConstruction.CreaseId,
                    PrintRepeatId = MaterialModel.CompositionAndConstruction.PrintRepeatId,
                    HandFeelIdList = MaterialModel.CompositionAndConstruction.HandFeelIdList
                },
                CareInstructionTypeId = (int)MaterialModel.CareInstructionTypeId,
                CompanyId = MaterialModel.Company.Id,
                PurchaseDetail = new()
                {
                    TenantId = MaterialModel.PurchaseDetail.TenantId,
                    IsActive = MaterialModel.PurchaseDetail.IsActive,
                    Price = MaterialModel.PurchaseDetail.Price,
                    Count = MaterialModel.PurchaseDetail.Count,
                    CurrencyId = MaterialModel.PurchaseDetail.CurrencyId,
                    PricingTypeId = MaterialModel.PurchaseDetail.PricingTypeId,
                    UnitOfMeasurementId = MaterialModel.PurchaseDetail.UnitOfMeasurementId,
                    UpchargeTypeId = MaterialModel.PurchaseDetail.UpchargeTypeId,
                    UpchargePrice = MaterialModel.PurchaseDetail.UpchargePrice,
                    UpchargePercentage = MaterialModel.PurchaseDetail.UpchargePercentage,
                    BelowMinimumOrderQuantityCount = MaterialModel.PurchaseDetail.BelowMinimumOrderQuantityCount,
                    BelowMinimumOrderQuantityCurrencyId = MaterialModel.PurchaseDetail.BelowMinimumOrderQuantityCurrencyId,
                    BelowMinmumOrderQuantityUnitOfMeasurementId = MaterialModel.PurchaseDetail.BelowMinmumOrderQuantityUnitOfMeasurementId,
                    GeneralInformationMinimumOrderQuantity = MaterialModel.PurchaseDetail.GeneralInformationMinimumOrderQuantity,
                    GeneralInformationMinimumColorQuantity = MaterialModel.PurchaseDetail.GeneralInformationMinimumColorQuantity,
                    GeneralInformationUnitOfMeasurementId = MaterialModel.PurchaseDetail.GeneralInformationUnitOfMeasurementId,
                    LeadTime = MaterialModel.PurchaseDetail.LeadTime,
                    ShippingTimeByAir = MaterialModel.PurchaseDetail.ShippingTimeByAir,
                    ShippingTimeBySea = MaterialModel.PurchaseDetail.ShippingTimeBySea,
                    RequestId = MaterialModel.PurchaseDetail.RequestId
                }
            };

            var json = JsonSerializer.Serialize(createMaterialModel);

            Console.WriteLine(json);


            //return Guid.NewGuid();

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/Create";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            MaterialModel material = new();

            Guid materialId = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                material = data.Result;

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/inventory/{material.CategoryValue.ToLower()}");

                materialId = material.Id;

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }

            return materialId;
        }

        public async Task<GraphMaterialModel> GetTopUsedMaterial(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetTopUsedMaterial?";
            // var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetAll?";

            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphMaterialModel>(responseStream);
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

        public async Task<GraphMaterialModel> GetMaterialPerMaterialType(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetMaterialPerType?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphMaterialModel>(responseStream);
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

        public async Task<GraphMaterialModel> GetColor(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetMaterialPerColor?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphMaterialModel>(responseStream);
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

        public async Task<GraphMaterialModel> GetMaterialPerMaterialTypes(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetMaterialPerMaterialTypes?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphMaterialModel>(responseStream);
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

        public async Task<GraphMaterialModel> GetMaterialCountPerInfluencerAndMaterialType(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetMaterialCountPerInfluencerAndMaterialType?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GraphMaterialModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GraphMaterialModel>(responseStream);
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

        public async Task<WarehouseCapacityPerMaterialTypeModel> GetWarehouseCapacityPerMaterialType(int? categoryId)
        {
            var url = $"{_configuration["App:ServerRootAddress"]}/Material/GetWarehouseCapacityPerMaterialType?";
            if (categoryId != null)
                url += "categoryId=" + HttpUtility.UrlEncode("" + categoryId) + "&";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            WarehouseCapacityPerMaterialTypeModel result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<WarehouseCapacityPerMaterialTypeModel>(responseStream);
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

        public async Task<bool> CreateRollReservation(List<CreateRollReservationModel> rollReservations)
        {
            var json = JsonSerializer.Serialize(rollReservations);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Material/CreateRollReservation";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            bool result;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                //var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                result = true;

                //await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/inventory/{material.CategoryValue.ToLower()}");

            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);

                result = false;
            }

            return result;
        }

    }
}

