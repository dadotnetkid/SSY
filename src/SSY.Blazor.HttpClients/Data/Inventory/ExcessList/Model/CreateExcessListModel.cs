using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model;

public class CreateExcessListModel
{

    [JsonPropertyName("tenantId")]
    public Guid TenantId { get; set; } 

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("companyId")]
    public int CompanyId { get; set; }

    [JsonPropertyName("mediaFileId")]
    public Guid MediaFileId { get; set; }

    [JsonPropertyName("mediaFile")]
    public CreateMediaFileModel MediaFile { get; set; } = new();

    [Required]
    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }
}