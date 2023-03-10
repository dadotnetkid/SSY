using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model
{
    public class ColorOptionModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("colorValue")]
        public string ColorValue { get; set; }

        [JsonPropertyName("typeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("typeValue")]
        public string MaterialTypeName { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        public List<MaterialModel> MaterialModelList { get; set; } = new();

        [JsonPropertyName("isApproved")]
        public bool? ColorOptionIsApproved { get; set; }

        [JsonPropertyName("isRejected")]
        public bool? ColorOptionIsRejected{ get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }

        [JsonPropertyName("rollIds")]
        public string RollIds { get; set; }

        [JsonPropertyName("maxQuantity")]
        public int MaxQuantity { get; set; }

        public bool Approve { get; set; } = false;
        public bool Reject { get; set; } = false;

        public bool IsRejected { get; set; } = false;
        public bool IsApproved { get; set; } = false;

        public double ReservedCount { get; set; } = 0;
        public string Influencer { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
    }

}
