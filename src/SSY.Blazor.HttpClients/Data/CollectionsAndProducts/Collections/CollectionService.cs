using System;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections
{
    public class CollectionService
    {
        public CollectionService(IJSRuntime js,
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

        public async Task<GetAllCollectionList> GetAllCollectionV2(string? keyword, string? sorting, int? skipCount, int? maxResultCount)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection?";
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

            GetAllCollectionList result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllCollectionList>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All MaterialType Failed!", $"{data.Error..Message}");
                System.Console.WriteLine(data.Error.Message);
            }

            return result;
        }

        public async Task<CollectionDto> GetCollectionV2(Guid id)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/{id}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            CollectionDto result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<CollectionDto>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All MaterialType Failed!", $"{data.Error..Message}");
                System.Console.WriteLine(data.Error.Message);
            }

            return result;
        }

        public async Task<(CollectionDto, bool)> CreateCollectionV2(CollectionModel input)
        {
            List<CreateCollectionProductTypeDto> productTypes = new();
            List<CreateCollectionInfluencerDto> influencers = new();
            List<CreateColorOptionDto> colorOptions = new();

            CollectionDto collectionDto = new();

            // Product Types
            input.MaterialProductTypeList.ForEach(item =>
            {
                item.ProductTypeIds.ForEach(x => {
                    productTypes.Add(new() { IsActive = true, ProductTypeId = x, CollectionId = input.Id, MaterialTypeShortCode = item.MaterialTypeShortCode, MaterialTypeValue = item.MaterialTypeName });
                });
            });

            // Influencers
            input.influencers.ForEach(item => {
                influencers.Add(new() { IsActive = true, InfluencerId = item.Id, InfluencerFullName = item.InfluencerFullName, CollectionId = input.Id, InfluencerName = item.InfluencerName, InfluencerSurname = item.InfluencerSurame });
            });


            // Color Options
            input.ColorSelectionList.ForEach(item => {

                List<CreateColorOptionProductTypeDto> productTypes = new();
                List<CreateColorOptionFabricDto> fabrics = new();

                item.ProductTypeIds.ForEach(x => productTypes.Add(new() { IsActive = true, ProductTypeId = x }));

                CreateColorOptionDto colorOptionDto = new();

                colorOptionDto.IsActive = true;
                colorOptionDto.Title = item.Title;
                colorOptionDto.ColorId = item.ColorId;
                colorOptionDto.ColorValue = item.ColorValue;
                colorOptionDto.ColorShortCode = item.ColorShortCode;
                colorOptionDto.TypeId = item.MaterialTypeId;
                colorOptionDto.ProductTypes = productTypes;
              
                item.FabricSelectionList.ForEach(fabric => {

                    CreateColorOptionFabricDto fabricDto = new();
                    List<CreateColorOptionFabricRollDto> rolls = new();

                    fabricDto.MaterialId = fabric.MaterialId;
                   
                    fabricDto.FabricComposition = fabric.FabricComposition;
                    fabricDto.CareInstruction = fabric.CareInstruction;
                    fabricDto.ColorCode = fabric.ColorCode;
                    fabricDto.ItemCode = fabric.ItemCode;
                    fabricDto.UnitOfMeasurement = fabric.UnitOfMeasurement;
                    fabricDto.CuttableWidth = fabric.CuttableWidth;
                    fabricDto.ContentDescription = fabric.ContentDescription;
                    fabricDto.Price = fabric.Price;
                    fabricDto.Supplier = fabric.Supplier;

                    fabric.SelectedRollIds.ForEach(roll => {
                        rolls.Add(new() { IsActive = true, RollId = roll });
                    });

                    fabricDto.Rolls = rolls;
                    fabrics.Add(fabricDto);

                });

                colorOptionDto.Fabrics = fabrics;

                colorOptions.Add(colorOptionDto);
            });

            CreateCollectionDto createCollectionDto = new()
            {
                IsActive = true,

                Name = input.Name,
                Availability = input.Availability,
                IsPublished = input.IsPublished,
                Year = input.Year,
                CollectionDevelopmentStartDate = DateTime.Now,
                ProvisionalLaunchDate = input.ProvisionalLaunchDate,

                SeasonId = input.SeasonId,
                PricePointId = input.PricePointId,
                FactoryId = input.FactoryId,
                ShippingTypeId = input.ShippingTypeId,
                MarketingTypeId = input.MarketingTypeId,
                DesignStatusId = input.DesignStatusId,
                StatusId = input.StatusId,

                ProductTypes = productTypes,
                Influencers = influencers,
                ColorOptions = colorOptions
            };


            var json = JsonSerializer.Serialize(createCollectionDto);

            Console.WriteLine(json);

            bool result = default;

            var validationResult = await CreateValidationAsyncV2(createCollectionDto);

            if (validationResult == true)
            {
                //await _js.InvokeVoidAsync("defaultMessage", "info", "", $"PASSED!");

                var url = $"{_configuration["App:ProductServerRootAddress"]}/collection";

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("User-Agent", "Inventory");
                request.Content = content;

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                //MaterialModel material = new();

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();

                    var data = await JsonSerializer.DeserializeAsync<CollectionDto>(responseStream);
                    collectionDto = data;
                    result = true;
                    //await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", $"/collectionandproduct/collection");
                }
                else
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                    result = false;
                }
            }

            var res = (collectionDto, result);

            return res;
        }

        public async Task DeleteCollectionV2(Guid id)
        {

            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/{id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
                //await GetCollection(data.Result.Value);
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

        public async Task CancelCollectionV2(Guid id)
        {

            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/{id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Successfully Deleted!", "");
                //await GetCollection(data.Result.Value);
            }
            else
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                var error = data.Error;
                await _js.InvokeVoidAsync("defaultMessage", "error", "Cancel Creation of Collection Failed!", $"{error.Message}");
                Console.WriteLine(JsonSerializer.Serialize(error));
            }

        }

        public async Task<(CollectionDto, bool)> UpdateCollectionV2(CollectionModel input)
        {
            List<CreateCollectionProductTypeDto> productTypes = new();
            List<CreateCollectionInfluencerDto> influencers = new();
            List<UpdateColorOptionDto> colorOptions = new();
            List<UpdateCollectionSizeDto> sizes = new();

            CollectionDto collectionDto = new();

            // Product Types
            input.MaterialProductTypeList.ForEach(item =>
            {
                item.ProductTypeIds.ForEach(x => {
                    productTypes.Add(new() { IsActive = true, ProductTypeId = x, CollectionId = input.Id, MaterialTypeShortCode = item.MaterialTypeShortCode, MaterialTypeValue = item.MaterialTypeName });
                });
            });

            // Influencers
            input.influencers.ForEach(item => {
                influencers.Add(new() { IsActive = true, InfluencerId = item.Id, InfluencerFullName = item.InfluencerFullName, CollectionId = input.Id, InfluencerName = item.InfluencerName, InfluencerSurname = item.InfluencerSurame });
            });

            // Color Options
            input.ColorSelectionList.ForEach(item => {

                List<UpdateColorOptionProductTypeDto> productTypes = new();

                item.ProductTypeIds.ForEach(x => productTypes.Add(new() { IsActive = true, ProductTypeId = x, ColorOptionId = item.Id }));

                UpdateColorOptionDto colorOptionDto = new();
                List<UpdateColorOptionFabricDto> fabrics = new();

                colorOptionDto.Id = item.Id;
                colorOptionDto.CollectionId = input.Id;
                colorOptionDto.IsActive = true;

                colorOptionDto.Title = item.Title;
                colorOptionDto.ColorId = item.ColorId;
                colorOptionDto.ColorValue = item.ColorValue;
                colorOptionDto.ColorShortCode = item.ColorShortCode;
                colorOptionDto.TypeId = item.MaterialTypeId;
                colorOptionDto.ProductTypes = productTypes;

                item.FabricSelectionList.ForEach(fabric => {

                    UpdateColorOptionFabricDto fabricDto = new();
                    List<UpdateColorOptionFabricRollDto> rolls = new();

                    fabricDto.ColorOptionId = item.Id;
                    fabricDto.MaterialId = fabric.MaterialId;
                    fabricDto.FabricComposition = item.FabricComposition;
                    fabricDto.CareInstruction = item.CareInstruction;
                    fabricDto.ColorCode = item.ColorCode;
                    fabricDto.ItemCode = item.ItemCode;
                    fabricDto.UnitOfMeasurement = item.UnitOfMeasurement;
                    fabricDto.CuttableWidth = item.CuttableWidth;
                    fabricDto.ContentDescription = item.ContentDescription;
                    fabricDto.Price = item.Price;
                    fabricDto.Supplier = item.Supplier;

                    fabric.SelectedRolls.ForEach(roll => {
                        rolls.Add(new() { IsActive = true, RollId = roll.Id });
                    });

                    fabricDto.Rolls = rolls;
                    fabrics.Add(fabricDto);

                });

                colorOptionDto.Fabrics = fabrics;

                colorOptions.Add(colorOptionDto);

            });

            // Sizing Options
            input.SizingOptionIds.ForEach(x => {
                sizes.Add(new() { IsActive = true, CollectionId = input.Id, SizeId = x });
            });

            UpdateCollectionDto updateCollectionDto = new()
            {
                Id = input.Id,
                IsActive = true,

                Name = input.Name,
                Availability = input.Availability,
                IsPublished = input.IsPublished,
                Year = input.Year,
                CollectionDevelopmentStartDate = input.CollectionDevelopmentStartDate,
                ProvisionalLaunchDate = input.ProvisionalLaunchDate,

                SeasonId = input.SeasonId,
                PricePointId = input.PricePointId,
                FactoryId = input.FactoryId,
                ShippingTypeId = input.ShippingTypeId,
                MarketingTypeId = input.MarketingTypeId,
                DesignStatusId = input.DesignStatusId,
                StatusId = input.StatusId,

                ProductTypes = productTypes,
                Influencers = influencers,
                ColorOptions = colorOptions,
                Sizes = sizes,
                AssignedTo = input.AssignedTo,
                CurrentFabricCount = input.CurrentFabricCount
            };

            var json = JsonSerializer.Serialize(updateCollectionDto);

            Console.WriteLine(json);

            var validationResult = await UpdateValidationAsyncV2(updateCollectionDto);

            bool isSuccess = false;

            if (validationResult == true)
            {
                //await _js.InvokeVoidAsync("defaultMessage", "info", "", $"PASSED!");

                var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/{input.Id}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("User-Agent", "Inventory");
                request.Content = content;

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                //MaterialModel material = new();

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();

                    var data = await JsonSerializer.DeserializeAsync<CollectionDto>(responseStream);
                    collectionDto = data;
                    isSuccess = true;
                    await _js.InvokeVoidAsync("defaultMessage", "success", "Collection Successfully Updated!", "");
                }
                else
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    isSuccess = false;
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Update Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }

            var result = (collectionDto, isSuccess);

            return result;
        }

        public async Task<bool> ApproveColorOptionV2(ApproveRejectColorOptionModel input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/approve-color-option";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            //MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                //var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                //material = data.Result;

                // await _js.InvokeVoidAsync("defaultMessage", "success", "Color Option Approved Successfully!", "");

                return true;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Color Option Approved Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);

                return false;
            }
        }

        public async Task<bool> RejectColorOptionV2(ApproveRejectColorOptionModel input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/reject-color-option";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            //MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                //var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                //material = data.Result;

                await _js.InvokeVoidAsync("defaultMessage", "success", "Color Option Rejected Successfully!", "");

                return true;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Color Option Rejected Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);

                return false;
            }
        }

        public async Task<bool> PublishCollectionV2(Guid input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/publish-collection/{input}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            request.Content = content;

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            //MaterialModel material = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                //var data = await JsonSerializer.DeserializeAsync<GetMaterialOutputModel>(responseStream);
                //material = data.Result;

                await _js.InvokeVoidAsync("defaultMessage", "success", "Collection Published Successfully!", "");

                return true;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Collection Published Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);

                return false;
            }
        }

        public async Task CreateRollReservation(CreateRollReservationModel reservation)
        {
            var json = JsonSerializer.Serialize(reservation);
            System.Console.WriteLine(json);

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
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Reservation Success!", "");
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

        public async Task<GetAllCollectionListDto> GetAllCollectionList()
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/collection-list";
            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllCollectionListDto result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<GetAllCollectionListDto>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All MaterialType Failed!", $"{data.Error..Message}");
                System.Console.WriteLine(data.Error.Message);
            }

            return result;
        }

        public async Task<bool> CreateValidationAsync(CreateCollectionInputModel input)
        {
            bool Overview = false;
            bool Factory = false;
            bool Season = false;
            bool ColorOptions = false;

            // Overview Validations

            #region Validation for Influencers

            if (input.InfluencerIds.Count == 0)
            {
                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Influencer/s.");
                Overview = false;
            }
            else
            {
                #region Valdation for Factory

                if (input.FactoryId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Factory.");
                    Factory = false;
                }
                else
                {
                    Factory = true;
                }

                #endregion

                #region Valdation for Season

                if (input.SeasonId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Season.");
                    Season = false;
                }
                else
                {
                    Season = true;
                }

                #endregion

                #region Valdation for Product Types

                var materialTypeHasNoProductTypes = input.MaterialProductTypeIds.Find(x => x.ProductTypeIds.Count == 0 && x.TypeId > 0);

                if (input.MaterialProductTypeIds.Count == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Material Type/s and Product Type/s");
                    Overview = false;
                }
                else
                {
                    Overview = true;

                    #region Valdation for Color Options

                    if (input.ColorOptions.Count == 0)
                    {
                        await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color Option/s.");
                        ColorOptions = false;
                    }
                    else
                    {
                        List<NoSelectedColor> noSelectedColors = new();
                        List<NoSelectedFabric> noSelectedFabrics = new();
                        List<NoSelectedRoll> noSelectedRolls = new();

                        input.ColorOptions.ForEach(x =>
                        {
                            var title = x.Title;
                            var color = x.ColorId;
                            var fabric = x.MaterialId;
                            List<Guid> rolls = x.RollIds;
                            var productTypes = x.ProductTypeIds;
                            var colorOption = x.Id;

                            if (color == 0)
                            {
                                noSelectedColors.Add(new()
                                {
                                    ColorId = color,
                                    Title = title
                                });
                            }

                            if (fabric.Equals(Guid.Empty))
                            {
                                noSelectedFabrics.Add(new()
                                {
                                    MaterialId = fabric,
                                    Title = title
                                });
                            }

                            if (rolls.Count == 0)
                            {
                                noSelectedRolls.Add(new()
                                {
                                    Title = title
                                });
                            }

                        });

                        #region Validation for Color

                        if (noSelectedColors.Count > 0)
                        {
                            List<string> titles = new();
                            noSelectedColors.ForEach(x => { titles.Add(x.Title); });

                            await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                            ColorOptions = false;
                        }
                        else
                        {
                            #region Validation for Fabric

                            if (noSelectedFabrics.Count > 0)
                            {
                                List<string> titles = new();
                                noSelectedFabrics.ForEach(x => { titles.Add(x.Title); });

                                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Fabric for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                ColorOptions = false;
                            }
                            else
                            {
                                #region Validation for Roll

                                if (noSelectedRolls.Count > 0)
                                {
                                    List<string> titles = new();
                                    noSelectedRolls.ForEach(x => { titles.Add(x.Title); });

                                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Roll/s for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                    ColorOptions = false;
                                }
                                else
                                {
                                    ColorOptions = true;
                                }

                                #endregion
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            if (Overview == true && Factory == true && Season == true && ColorOptions == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CreateValidationAsyncV2(CreateCollectionDto input)
        {
            bool Overview = false;
            bool Factory = false;
            bool Season = false;
            bool ColorOptions = false;

            // Overview Validations

            #region Validation for Influencers

            if (input.Influencers.Count == 0)
            {
                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Influencer/s.");
                Overview = false;
            }
            else
            {
                #region Valdation for Factory

                if (input.FactoryId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Factory.");
                    Factory = false;
                }
                else
                {
                    Factory = true;
                }

                #endregion

                #region Valdation for Season

                if (input.SeasonId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Season.");
                    Season = false;
                }
                else
                {
                    Season = true;
                }

                #endregion

                #region Valdation for Product Types


                if (input.ProductTypes.Count == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Material Type/s and Product Type/s");
                    Overview = false;
                }
                else
                {
                    Overview = true;

                    #region Valdation for Color Options

                    if (input.ColorOptions.Count == 0)
                    {
                        await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color Option/s.");
                        ColorOptions = false;
                    }
                    else
                    {
                        List<NoSelectedColor> noSelectedColors = new();
                        List<NoSelectedFabric> noSelectedFabrics = new();
                        List<NoSelectedRoll> noSelectedRolls = new();

                        input.ColorOptions.ForEach(x =>
                        {
                            var title = x.Title;
                            var color = x.ColorId;
                           
                            var productTypes = x.ProductTypes;
                            //var colorOption = x.Id;

                            if (color == 0)
                            {
                                noSelectedColors.Add(new()
                                {
                                    ColorId = color,
                                    Title = title
                                });
                            }

                            x.Fabrics.ForEach(fabric => {

                                if (fabric.Equals(Guid.Empty))
                                {
                                    noSelectedFabrics.Add(new()
                                    {
                                        MaterialId = fabric.MaterialId,
                                        Title = title
                                    });
                                }

                                List<CreateColorOptionFabricRollDto> rolls = fabric.Rolls;

                                if (rolls.Count == 0)
                                {
                                    noSelectedRolls.Add(new()
                                    {
                                        Title = title
                                    });
                                }

                            });
                        });

                        #region Validation for Color

                        if (noSelectedColors.Count > 0)
                        {
                            List<string> titles = new();
                            noSelectedColors.ForEach(x => { titles.Add(x.Title); });

                            await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                            ColorOptions = false;
                        }
                        else
                        {
                            #region Validation for Fabric

                            if (noSelectedFabrics.Count > 0)
                            {
                                List<string> titles = new();
                                noSelectedFabrics.ForEach(x => { titles.Add(x.Title); });

                                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Fabric for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                ColorOptions = false;
                            }
                            else
                            {
                                #region Validation for Roll

                                if (noSelectedRolls.Count > 0)
                                {
                                    List<string> titles = new();
                                    noSelectedRolls.ForEach(x => { titles.Add(x.Title); });

                                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Roll/s for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                    ColorOptions = false;
                                }
                                else
                                {
                                    ColorOptions = true;
                                }

                                #endregion
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            if (Overview == true && Factory == true && Season == true && ColorOptions == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateValidationAsync(UpdateCollectionInputModel input)
        {
            bool Overview = false;
            bool Factory = false;
            bool Season = false;
            bool ColorOptions = false;

            // Overview Validations

            #region Validation for Influencers

            if (input.InfluencerIds.Count == 0)
            {
                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Influencer/s.");
                Overview = false;
            }
            else
            {
                #region Valdation for Factory

                if (input.FactoryId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Factory.");
                    Factory = false;
                }
                else
                {
                    Factory = true;
                }

                #endregion

                #region Valdation for Season

                if (input.SeasonId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Season.");
                    Season = false;
                }
                else
                {
                    Season = true;
                }

                #endregion

                #region Valdation for Product Types

                var materialTypeHasNoProductTypes = input.MaterialProductTypeIds.Find(x => x.ProductTypeIds.Count == 0 && x.TypeId > 0);

                if (input.MaterialProductTypeIds.Count == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Material Type/s and Product Type/s");
                    Overview = false;
                }
                else
                {
                    Overview = true;

                    #region Valdation for Color Options

                    if (input.ColorOptions.Count == 0)
                    {
                        await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color Option/s.");
                        ColorOptions = false;
                    }
                    else
                    {
                        List<NoSelectedColor> noSelectedColors = new();
                        List<NoSelectedFabric> noSelectedFabrics = new();
                        List<NoSelectedRoll> noSelectedRolls = new();

                        input.ColorOptions.ForEach(x =>
                        {
                            var title = x.Title;
                            var color = x.ColorId;
                            var fabric = x.MaterialId;
                            List<Guid> rolls = x.RollIds;
                            var productTypes = x.ProductTypeIds;
                            var colorOption = x.Id;

                            if (color == 0)
                            {
                                noSelectedColors.Add(new()
                                {
                                    ColorId = color,
                                    Title = title
                                });
                            }

                            if (fabric.Equals(Guid.Empty))
                            {
                                noSelectedFabrics.Add(new()
                                {
                                    MaterialId = fabric,
                                    Title = title
                                });
                            }

                            if (rolls.Count == 0)
                            {
                                noSelectedRolls.Add(new()
                                {
                                    Title = title
                                });
                            }

                        });

                        #region Validation for Color

                        if (noSelectedColors.Count > 0)
                        {
                            List<string> titles = new();
                            noSelectedColors.ForEach(x => { titles.Add(x.Title); });

                            await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                            ColorOptions = false;
                        }
                        else
                        {
                            #region Validation for Fabric

                            if (noSelectedFabrics.Count > 0)
                            {
                                List<string> titles = new();
                                noSelectedFabrics.ForEach(x => { titles.Add(x.Title); });

                                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Fabric for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                ColorOptions = false;
                            }
                            else
                            {
                                #region Validation for Roll

                                if (noSelectedRolls.Count > 0)
                                {
                                    List<string> titles = new();
                                    noSelectedRolls.ForEach(x => { titles.Add(x.Title); });

                                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Roll/s for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                    ColorOptions = false;
                                }
                                else
                                {
                                    ColorOptions = true;
                                }

                                #endregion
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            if (Overview == true && Factory == true && Season == true && ColorOptions == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateValidationAsyncV2(UpdateCollectionDto input)
        {
            bool Overview = false;
            bool Factory = false;
            bool Season = false;
            bool ColorOptions = false;

            // Overview Validations

            #region Validation for Influencers

            if (input.Influencers.Count == 0)
            {
                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Influencer/s.");
                Overview = false;
            }
            else
            {
                #region Valdation for Factory

                if (input.FactoryId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Factory.");
                    Factory = false;
                }
                else
                {
                    Factory = true;
                }

                #endregion

                #region Valdation for Season

                if (input.SeasonId == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Season.");
                    Season = false;
                }
                else
                {
                    Season = true;
                }

                #endregion

                #region Valdation for Product Types

                if (input.ProductTypes.Count == 0)
                {
                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Material Type/s and Product Type/s");
                    Overview = false;
                }
                else
                {
                    Overview = true;

                    #region Valdation for Color Options

                    if (input.ColorOptions.Count == 0)
                    {
                        await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color Option/s.");
                        ColorOptions = false;
                    }
                    else
                    {
                        List<NoSelectedColor> noSelectedColors = new();
                        List<NoSelectedFabric> noSelectedFabrics = new();
                        List<NoSelectedRoll> noSelectedRolls = new();

                        input.ColorOptions.ForEach(x =>
                        {
                            var title = x.Title;
                            var color = x.ColorId;
                           
                            var productTypes = x.ProductTypes;

                            if (color == 0)
                            {
                                noSelectedColors.Add(new()
                                {
                                    ColorId = color,
                                    Title = title
                                });
                            }

                            x.Fabrics.ForEach(fabric => {

                                if (fabric.Equals(Guid.Empty))
                                {
                                    noSelectedFabrics.Add(new()
                                    {
                                        MaterialId = fabric.MaterialId,
                                        Title = title
                                    });
                                }

                                List<UpdateColorOptionFabricRollDto> rolls = fabric.Rolls;

                                if (rolls.Count == 0)
                                {
                                    noSelectedRolls.Add(new()
                                    {
                                        Title = title
                                    });
                                }
                            });

                        });

                        #region Validation for Color

                        if (noSelectedColors.Count > 0)
                        {
                            List<string> titles = new();
                            noSelectedColors.ForEach(x => { titles.Add(x.Title); });

                            await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Color for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                            ColorOptions = false;
                        }
                        else
                        {
                            #region Validation for Fabric

                            if (noSelectedFabrics.Count > 0)
                            {
                                List<string> titles = new();
                                noSelectedFabrics.ForEach(x => { titles.Add(x.Title); });

                                await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Fabric for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                ColorOptions = false;
                            }
                            else
                            {
                                #region Validation for Roll

                                if (noSelectedRolls.Count > 0)
                                {
                                    List<string> titles = new();
                                    noSelectedRolls.ForEach(x => { titles.Add(x.Title); });

                                    await _js.InvokeVoidAsync("defaultMessage", "warning", "", $"Please select Roll/s for {ReplaceString(JsonSerializer.Serialize(titles))}.");
                                    ColorOptions = false;
                                }
                                else
                                {
                                    ColorOptions = true;
                                }

                                #endregion
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            if (Overview == true && Factory == true && Season == true && ColorOptions == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CollectionTimelineOutputModel>> GetCollectionTimelineV2Async()
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection/collection-timeline";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            var responseStream = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CollectionTimelineOutputModel>>(responseStream);
            return result;
        }

        public async Task<CollectionDropdownDto> GetCollectionDropdowns()
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/collection-dropdown/dropdowns";
            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/* ");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            CollectionDropdownDto result = new();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<CollectionDropdownDto>(responseStream);
                result = data;
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                //await _js.InvokeVoidAsync("defaultMessage", "error", "Get All MaterialType Failed!", $"{data.Error..Message}");
                System.Console.WriteLine(data.Error.Message);
            }

            return result;
        }


        public class NoSelectedColor
        {
            public int ColorId { get; set; }
            public string Title { get; set; }
        }

        public class NoSelectedFabric
        {
            public Guid MaterialId { get; set; }
            public string Title { get; set; }
        }

        public class NoSelectedRoll
        {
            public string Title { get; set; }
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
        }

    }
}

