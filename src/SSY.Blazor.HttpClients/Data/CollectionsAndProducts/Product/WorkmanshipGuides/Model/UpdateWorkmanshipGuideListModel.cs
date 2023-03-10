using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;

public class UpdateWorkmanshipGuideListModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("typeId")]
    public int TypeId { get; set; }

    [JsonPropertyName("accountabilityId")]
    public Guid MediaFileId { get; set; }

    [JsonPropertyName("accountability")]
    public MediaFileModel MediaFile { get; set; } = new();
}