using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Comments
{
    public class CommentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("rootId")]
        public Guid? RootId { get; set; }

        [JsonPropertyName("parentId")]
        public Guid? ParentId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("pageName")]
        public string? PageName { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("cc")]
        public string CC { get; set; }
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("sectionId")]
        public int SectionId { get; set; }

        [JsonPropertyName("sectionLabel")]
        public string SectionLabel { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonPropertyName("subjectId")]
        public int SubjectId { get; set; }

        [JsonPropertyName("subjectLabel")]
        public string SubjectLabel { get; set; }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonPropertyName("products")]
        public string Products { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("nameOfCommentor")]
        public string NameOfCommentor { get; set; } = "Jerson billones";

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }

        [JsonPropertyName("files")]
        public List<Files> Files { get; set; } = new();

        [JsonPropertyName("comments")]
        public List<CommentModel> Comments { get; set; } = new();
        [JsonPropertyName("replies")]
        public List<CommentModel> Replies { get; set; } = new();

        public List<string> Tos { get; set; } = new();
        public List<string> CCs { get; set; } = new();

    }

    public class Files
    {
        public string Value { get; set; }

        public string Extension { get; set; }

    }


}



