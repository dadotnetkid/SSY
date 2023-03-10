using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.SwatchList.Model;

public class CreateOutputSwatchListModel
{

    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("isReceived")]
    public bool IsReceived { get; set; }

    [JsonPropertyName("companyId")]
    public int CompanyId { get; set; }

    [JsonPropertyName("mediaFileId")]
    public Guid MediaFileId { get; set; }

    [JsonPropertyName("mediaFile")]
    public MediaFileModel MediaFile { get; set; } = new();

    [Required]
    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }
}