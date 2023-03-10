using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.SampleImageModel
{
    public class InfluencerSampleImagesModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; }
        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; }
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("frontImageUrl")]
        public string FrontImageUrl { get; set; }

        [JsonPropertyName("isFrontImageApprove")]

        public bool? IsFrontImageApprove { get; set; }
        [JsonPropertyName("backImageUrl")]
        public string BackImageUrl { get; set; }
        [JsonPropertyName("isBackImageApprove")]
        public bool? IsBackImageApprove { get; set; }
        [JsonPropertyName("leftSideImageUrl")]
        public string LeftSideImageUrl { get; set; }
        [JsonPropertyName("rightSideImageUrl")]
        public string RightSideImageUrl { get; set; }
        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}