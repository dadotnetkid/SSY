using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products
{

    public class ProductService
    {
        public ProductService(IJSRuntime js,
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

        public async Task<ProductModel> GetProduct(Guid id)
        {
            ProductModel result = new();
            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/{id}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ProductModel>(responseStream);
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

        public async Task<GetAllProductOutputModel> GetAllProduct(string? sorting, int? skipCount, int? maxResultCount, bool? isActive = null)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/product?";
            if (sorting != null)
                url += "Sorting=" + HttpUtility.UrlEncode("" + sorting) + "&";
            if (skipCount != null)
                url += "SkipCount=" + HttpUtility.UrlEncode("" + skipCount) + "&";
            if (maxResultCount != null)
                url += "MaxResultCount=" + HttpUtility.UrlEncode("" + maxResultCount) + "&";
            if (isActive != null)
                url += "IsActive=" + HttpUtility.UrlEncode("" + isActive) + "&";
            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            // request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllProductOutputModel result = new();

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<GetAllProductOutputModel>(responseStream);
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

        public async Task<bool> CreateProduct(CreateProductModel input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> CreateShopify(ShopifyModel input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/Create";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> CreateProductList(List<CreateProductModel> input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/list";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> CreateProductLists(List<CreateProductDto> input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/list";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        // public async Task<List<ProductModel>> CreateBulkProduct(List<CreateProductModel> input)
        // {
        //     List<CreateProductInputModel> createProductInputModels = new();

        //     input.ForEach(x => {

        //         createProductInputModels.Add(new() {
        //             Name = x.ProductName,
        //             InfluencerIds = x.InfluencerIds,
        //             CollectionId = x.Collection,
        //             MaterialTypeId = x.MaterialType,
        //             ProductTypeId = x.ProductType,
        //             ProductApprovalStatusId = x.ApprovalStatus,
        //             ParentSku = x.Sku,
        //             FirstDesignDraftModel = x.FirstDesignDraftModel,
        //             ProductDesignStatusId = new int()
        //         });
        //     });

        //     var json = JsonSerializer.Serialize(createProductInputModels);

        //     Console.WriteLine(json);

        //     var url = $"{_configuration["App:ProductServerRootAddress"]}/product/product-list";

        //     var content = new StringContent(json, Encoding.UTF8, "application/json");
        //     var request = new HttpRequestMessage(HttpMethod.Post, url);
        //     request.Headers.Add("Accept", "*/*");
        //     request.Headers.Add("User-Agent", "Inventory");
        //     request.Content = content;

        //     var client = _clientFactory.CreateClient();
        //     var response = await client.SendAsync(request);

        //     List<ProductModel> result = new();

        //     if (response.IsSuccessStatusCode)
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var data = JsonSerializer.Deserialize<List<ProductModel>>(responseStream);
        //         result = data;

        //         //await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Added!", "", "");
        //     }
        //     else
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
        //         await _js.InvokeVoidAsync("defaultMessage", "error", "Bulk Parent Product Adding Failed!", $"{data.Error.Message}");
        //         Console.WriteLine(data.Error.Message);
        //     }

        //     return result;
        // }

        // public async Task UpdateProductV2(ProductModel input)
        // {
        //     // var sampleImage = input.SampleImagesModel;
        //     UpdateProductV2Model updateProductV2Model = new()
        //     {
        //         TenantId = null,
        //         IsActive = input.IsActive,
        //         Id = input.Id,
        //         Name = input.Name,
        //         CollectionId = input.CollectionId,
        //         StatusId = input.StatusId,
        //         ChildProducts = input.ChildProducts,
        //         ColorOptionId = input.ColorOptionId,
        //         ParentId = input.ParentId,
        //         ApprovalStatusId = input.ApprovalStatusId,
        //         Sku = input.Sku,
        //         TypeId = input.TypeId,
        //         ProductMediaFiles = input.ProductMediaFileIds,
        //         Shopify = new()
        //         {
        //             Id = input.Shopify.Id,
        //             Published = input.Shopify.Published,
        //             Name = input.Shopify.Name,
        //             Number = input.Shopify.Number,
        //             Price = input.Shopify.Price,
        //             FabricComposition = input.Shopify.FabricComposition,
        //             CareInstruction = input.Shopify.CareInstruction,
        //             Tags = input.Shopify.Tags,
        //             Description = input.Shopify.Description
        //         }
        //     };

        //     input.Shopify?.MediaFiles.ForEach(x =>
        //     {
        //         updateProductV2Model.Shopify.MediaFiles.Add(new() { MediaFileId = x.MediaFile.Id, OrderNumber = x.OrderNumber });
        //     });


        //     var json = JsonSerializer.Serialize(updateProductV2Model);

        //     Console.WriteLine("json");
        //     Console.WriteLine(json);

        //     var url = $"{_configuration["App:ProductServerRootAddress"]}/product/{input.Id}";

        //     var content = new StringContent(json, Encoding.UTF8, "application/json");
        //     var request = new HttpRequestMessage(HttpMethod.Put, url);
        //     request.Headers.Add("Accept", "*/*");
        //     request.Headers.Add("User-Agent", "Inventory");
        //     request.Content = content;

        //     var client = _clientFactory.CreateClient();
        //     var response = await client.SendAsync(request);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         await _js.InvokeVoidAsync("defaultMessage", "success", "Successfully Updated!", "");
        //     }
        //     else
        //     {
        //         using var responseStream = await response.Content.ReadAsStreamAsync();
        //         var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
        //         await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
        //         Console.WriteLine(data.Error.Message);
        //     }
        // }

        public async Task UpdateProductV2(ProductModel input)
        {
            // var sampleImage = input.SampleImagesModel;
            UpdateProductV2Model updateProductV2Model = new()
            {
                TenantId = null,
                IsActive = input.IsActive,
                Id = input.Id,
                Name = input.Name,
                CollectionId = input.CollectionId,
                StatusId = input.StatusId,
                ChildProducts = input.ChildProducts,
                ColorOptionId = input.ColorOptionId,
                ParentId = input.ParentId,
                ApprovalStatusId = input.ApprovalStatusId,
                Sku = input.Sku,
                TypeId = input.TypeId,
                ProductMediaFiles = input.ProductMediaFiles
                // Shopify = new()
                // {
                //     Id = input.Shopify.Id,
                //     Published = input.Shopify.Published,
                //     Name = input.Shopify.Name,
                //     Number = input.Shopify.Number,
                //     Price = input.Shopify.Price,
                //     FabricComposition = input.Shopify.FabricComposition,
                //     CareInstruction = input.Shopify.CareInstruction,
                //     Tags = input.Shopify.Tags,
                //     Description = input.Shopify.Description
                // }
            };

            // input.Shopify?.MediaFiles.ForEach(x =>
            // {
            //     updateProductV2Model.Shopify.MediaFiles.Add(new() { MediaFileId = x.MediaFile.Id, OrderNumber = x.OrderNumber });
            // });


            var json = JsonSerializer.Serialize(updateProductV2Model);

            Console.WriteLine("json");
            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/{input.Id}";

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
                await _js.InvokeVoidAsync("defaultMessage", "success", "Successfully Updated!", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task UpdateShopifyList(List<UpdateShopifyModel> input)
        {
            // var sampleImage = input.SampleImagesModel;

            var json = JsonSerializer.Serialize(input);

            Console.WriteLine("json");
            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/shopify-list";

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
                // await _js.InvokeVoidAsync("defaultMessage", "success", "Successfully Updated!", "");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }


        public async Task UpdateProduct(ProductModel input)
        {
            UpdateProductInputModel updateProductInputModel = new()
            {
                // Id = input.Id,
            };


            var json = JsonSerializer.Serialize(updateProductInputModel);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ServerRootAddress"]}/Product/Update";

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

                await _js.InvokeVoidAsync("defaultMessageWithRedirect", "success", "Successfully Updated!", "", $"/collectionandproduct/collections/details/{input.Id}");
            }
            else
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Updating Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }


        public async Task DeleteProduct(Guid id)
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/{id}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Sucess!", "");
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

        public async Task DeleteProductList(List<Guid> ids)
        {
            List<string> productIds = new();
            var param = string.Empty;

            ids.ForEach(x =>
            {
                productIds.Add($"ids={x}");
            });

            param = string.Join("&", productIds);

            Console.WriteLine(param);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/products-by-ids?{param}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                //await _js.InvokeVoidAsync("defaultMessage", "success", "Delete Sucess!", "");
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

        public async Task Approve(ApproveProductModel input)
        {
            try
            {

                var json = JsonSerializer.Serialize(input);

                Console.WriteLine(json);

                var url = $"{_configuration["App:ProductServerRootAddress"]}/product/approve";

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
                    await _js.InvokeVoidAsync("defaultMessage", "success", "Product/s successfully created!", "");
                }
                else
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await _js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task RejectChild(ApproveProductModel input)
        {
            try
            {
                var json = JsonSerializer.Serialize(input);

                Console.WriteLine(json);

                var url = $"{_configuration["App:ProductServerRootAddress"]}/product/reject-child";

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
                    //await _js.InvokeVoidAsync("defaultMessage", "success", "Color Option Approved Successfully!", "");
                }
                else
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                    await _js.InvokeVoidAsync("defaultMessage", "error", "Reject Product Failed!", $"{data.Error.Message}");
                    Console.WriteLine(data.Error.Message);
                }
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
                await _js.InvokeVoidAsync("defaultMessage", "error", "", $"Error: {ex.Message}{innerException}");
            }
        }

        public async Task<bool> InternalApproval(MediaFileApprovalDto input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/internal-approve-media-file-category";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> InternalRejection(MediaFileRejectionDto input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/internal-reject-media-file-category";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> InfluencerRejection(MediaFileRejectionDto input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/influencer-reject-media-file-category";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> AddRejectionComment(MediaFileRejectionDto input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/rejection-note";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<bool> InfluencerApproval(MediaFileApprovalDto input)
        {
            var json = JsonSerializer.Serialize(input);

            Console.WriteLine(json);

            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/influencer-approve-media-file-category";

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
                return true;
            }
            else
            {
                return false;
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<ErrorMessageOutputModel>(responseStream);
                await _js.InvokeVoidAsync("defaultMessage", "error", "Adding Failed!", $"{data.Error.Message}");
                Console.WriteLine(data.Error.Message);
            }
        }

        public async Task<GetAllProductListDto> GetAllProductList()
        {
            var url = $"{_configuration["App:ProductServerRootAddress"]}/product/product-list";
            url = url.Replace("/[?&]$/", "");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            // request.Headers.Add("User-Agent", "Inventory");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            GetAllProductListDto result = new();

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<GetAllProductListDto>(responseStream);
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


    }
}

