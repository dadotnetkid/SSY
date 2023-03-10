using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

public class UpdateMediaFileModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("originalFileName")]
    public string OriginalFileName { get; set; }

    [JsonPropertyName("storageFileName")]
    public string StorageFileName { get; set; }

    [JsonPropertyName("filePath")]
    public string FilePath { get; set; }

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }
}