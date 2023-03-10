using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Comments;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments
{
    public class TimelineAndCommentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("cc")]
        public string CC { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("section")]
        public string Section { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("products")]
        public string Products { get; set; }

        [JsonPropertyName("nameOfCommentor")]
        public string NameOfCommentor { get; set; } = "Jerson billones";


        [JsonPropertyName("comments")]
        public List<CommentModel> Comments { get; set; } = new();

    }
}


