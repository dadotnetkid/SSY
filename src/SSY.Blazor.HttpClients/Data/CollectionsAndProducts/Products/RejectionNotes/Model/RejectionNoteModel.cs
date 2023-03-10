using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

public class RejectionNoteModel
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

    [JsonPropertyName("creationTime")]
    public DateTime creationTime { get; set; }

    [JsonPropertyName("mediaFiles")]
    public List<RejectionNoteMediaFile> MediaFiles { get; set; } = new();

}


public class RejectionNoteMediaFile
{
    [JsonPropertyName("tenantId")]
    public Guid? TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("mediaFile")]
    public MediaFileModel MediaFile { get; set; } = new();
}