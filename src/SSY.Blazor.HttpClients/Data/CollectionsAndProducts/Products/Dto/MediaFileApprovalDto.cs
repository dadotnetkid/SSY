using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto
{
    public class MediaFileApprovalDto
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("mediaFileCategoryId")]
        public int MediaFileCategoryId { get; set; }

        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }
    }
}