using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto
{
    public class CreateProductDto
    {
        #region Common

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        #endregion

        #region Product

        [JsonPropertyName("collectionId")]
        public Guid? CollectionId { get; set; }

        [JsonPropertyName("approvalStatusId")]
        public int ApprovalStatusId { get; set; }

        [JsonPropertyName("childProducts")]
        public List<CreateProductDto> ChildProducts { get; set; } = new();

        [JsonPropertyName("accounting")]
        public CreateAccountingDto Accounting { get; set; } = new();

        [JsonPropertyName("pricing")]
        public CreatePricingDto Pricing { get; set; } = new();

        [JsonPropertyName("bomSummaries")]
        public List<CreateProductBomSummaryDto> BomSummaries { get; set; } = new();

        #endregion

        #region Child Product

        [JsonPropertyName("parentId")]
        public Guid? ParentId { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid? ColorOptionId { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("dropId")]
        public int? DropId { get; set; }

        [JsonPropertyName("shopify")]
        public CreateShopifyDto Shopify { get; set; } = new();

        #endregion

        public CreateProductDto()
        {
            ChildProducts = new();
            Accounting = new();
            Pricing = new();
            Shopify = new();
            BomSummaries = new();
        }
    }
}

