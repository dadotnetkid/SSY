using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Dto
{
    public class CreateBulkPurchaseOrderRequestDto
    {
        //[JsonPropertyName("id")]
        //public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("tcxCode")]
        public string TCXCode { get; set; }

        [JsonPropertyName("requiredYardage")]
        public double RequiredYardage { get; set; }

        [JsonPropertyName("approvedByLabDipShade")]
        public string? ApprovedByLabDipShade { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("companyId")]
        public int? CompanyId { get; set; }

        [JsonPropertyName("influencerId")]
        public Guid InfluencerId { get; set; }

        [JsonPropertyName("influencers")]
        public string Influencers { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid? CollectionId { get; set; }

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("addedBy")]
        public string AddedBy { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }
    }
}

