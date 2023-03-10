using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class CreateProductModel
    {
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("approvalStatusId")]
        public int ApprovalStatusId { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [JsonPropertyName("shippingTypeId")]
        public int ShippingTypeId { get; set; }

        [JsonPropertyName("colorId")]
        public int? ColorId { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid? ColorOptionId { get; set; }

        [JsonPropertyName("childProducts")]
        public List<CreateProductModel> ChildProducts { get; set; }

        [JsonPropertyName("bomSummaries")]
        public List<CreateProductBomSummaryDto> BomSummaries { get; set; }


        // for UI usage

        [JsonPropertyName("influencersName")]
        public string InfluencersName { get; set; }

        [JsonPropertyName("influencerIds")]
        public string InfluencerIds { get; set; }

        [JsonPropertyName("shopify")]
        public ShopifyModel Shopify { get; set; }

        [JsonPropertyName("pricing")]
        public CreatePricingModel Pricing { get; set; }

        [JsonPropertyName("accounting")]
        public CreateAccountingModel Accounting { get; set; }

        public CreateProductModel()
        {
            ChildProducts = new();
            Shopify = new();
            Accounting = new();
            Pricing = new();
            BomSummaries = new();
        }
    }

}
