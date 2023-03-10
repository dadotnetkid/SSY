using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Model
{
    public class UpdateBulkPurchaseOrderRequestModel
    {
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

        [JsonPropertyName("approvedByLabDipShade")]
        public string ApprovedByLabDipShade { get; set; }

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

        [JsonPropertyName("addedDate")]
        public DateTime AddedDate { get; set; }

        [JsonPropertyName("addedBy")]
        public string AddedBy { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}

