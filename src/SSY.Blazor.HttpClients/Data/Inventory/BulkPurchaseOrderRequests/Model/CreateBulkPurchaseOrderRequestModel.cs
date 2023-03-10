using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Model
{
    public class CreateBulkPurchaseOrderRequestModel
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonPropertyName("categoryValue")]
        public string CategoryValue { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("materialTypeLabel")]
        public string MaterialTypeLabel { get; set; }

        [JsonPropertyName("materialTypeValue")]
        public string MaterialTypeValue { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("colorId")]
        public int? ColorId { get; set; }

        [JsonPropertyName("colorLabel")]
        public string ColorLabel { get; set; }

        [JsonPropertyName("colorValue")]
        public string ColorValue { get; set; }

        [JsonPropertyName("colorGroup")]
        public string ColorGroup { get; set; }

        [JsonPropertyName("tcxCode")]
        public string TCXCode { get; set; }

        [JsonPropertyName("requiredYardage")]
        public double RequiredYardage { get; set; }

        [JsonPropertyName("approveLabDipShade")]
        public string ApproveLabDipShade { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("influencerId")]
        public Guid InfluencerId { get; set; }

        [JsonPropertyName("companyId")]
        public int? CompanyId { get; set; }

        [JsonPropertyName("company")]
        public CompanyModel Company { get; set; } = new();

        [JsonPropertyName("influencers")]
        public string Influencers { get; set; }

        //[JsonPropertyName("collectionName")]
        //public string CollectionName { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("addedBy")]
        public string AddedBy { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

    }
}

