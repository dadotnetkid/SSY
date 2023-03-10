using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model;

public partial class ExcessListModel
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
    public MediaFileModel MediaFile { get; set; } = new();

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }
}

public class Files
{
    public string Value { get; set; }
    public string Extension { get; set; }
}