using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;

public class WorkmanshipGuideListModel: BaseDropdownModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("typeId")]
    public int TypeId { get; set; }

    [JsonPropertyName("mediaFileId")]
    public Guid MediaFileId { get; set; }

    [JsonPropertyName("mediaFile")]
    public MediaFileModel MediaFile { get; set; } = new();

    public List<WorkmanshipGuideListModel> WorkmanshipGuidelists { get; set; } = new();

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Files
{
    public string Value { get; set; }
    public string Extension { get; set; }
}