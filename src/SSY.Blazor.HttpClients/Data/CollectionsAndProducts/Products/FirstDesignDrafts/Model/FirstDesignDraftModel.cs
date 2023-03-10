using System;
using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.FirstDesignDrafts.Model
{
    public class FirstDesignDraftModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("frontImageUrl")]
        public string FrontImageUrl { get; set; }

        [JsonPropertyName("isFrontImageApprove")]
        public bool? IsFrontImageApprove { get; set; }

        [JsonPropertyName("backImageUrl")]
        public string BackImageUrl { get; set; }

        [JsonPropertyName("isBackImageApprove")]
        public bool? IsBackImageApprove { get; set; }

        [JsonPropertyName("firstDesignDraftDetails")]
        public List<CreateFirstDesignDetailModel> DetailList { get; set; } = new();



    }
}