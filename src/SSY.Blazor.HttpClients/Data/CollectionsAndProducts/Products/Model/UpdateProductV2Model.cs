using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class UpdateProductV2Model
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [JsonPropertyName("approvalStatusId")]
        public int ApprovalStatusId { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid? ColorOptionId { get; set; }

        [JsonPropertyName("parentId")]
        public Guid? ParentId { get; set; }

        [JsonPropertyName("childProducts")]
        public List<ProductModel> ChildProducts { get; set; }

        [JsonPropertyName("shopify")]
        public UpdateShopifyModel Shopify { get; set; }

        [JsonPropertyName("productMediaFiles")]
        public List<ProductMediaFiles> ProductMediaFiles { get; set; }

        [JsonPropertyName("bomSummaries")]
        public List<ProductBomSummaryDto> BomSummaries { get; set; }

        public UpdateProductV2Model()
        {
            TenantId = null;
            IsActive = true;
            ChildProducts = new();
            Shopify = new();
            ProductMediaFiles = new();
            BomSummaries = new();
        }
    }
}