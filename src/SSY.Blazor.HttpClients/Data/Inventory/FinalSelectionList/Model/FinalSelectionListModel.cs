using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList.Model;

public class FinalSelectionListModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

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

    public List<FinalSelectionListModel> FinalSelectionLists { get; set; } = new();

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }
}

public class Files
{
    public string Value { get; set; }
    public string Extension { get; set; }
}