using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto
{
    public class MediaFileRejectionDto
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("isInternal")]
        public bool IsInternal { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("mediaFileCategoryId")]
        public int MediaFileCategoryId { get; set; }

        [JsonPropertyName("mediaFiles")]
        public List<MediaFilesDto> MediaFiles { get; set; }
    }

    public class MediaFilesDto
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("mediaFileId")]
        public Guid MediaFileId { get; set; }
    }

}