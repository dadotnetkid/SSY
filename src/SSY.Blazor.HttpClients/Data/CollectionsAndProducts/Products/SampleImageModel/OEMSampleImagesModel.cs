using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.SampleImageModel
{
    public class OEMSampleImageModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("frontUploadedFiles")]
        public string FrontUploadedFiles { get; set; }
        [JsonPropertyName("backUploadedFiles")]
        public string BackUploadedFiles { get; set; }
        [JsonPropertyName("leftUploadedFiles")]
        public string LeftUploadedFiles { get; set; }
        [JsonPropertyName("rightUploadedFiles")]
        public string RightUploadedFiles { get; set; }
        [JsonPropertyName("detailImages")]
        public List<string> DetailImages { get; set; } = new();
    }
}