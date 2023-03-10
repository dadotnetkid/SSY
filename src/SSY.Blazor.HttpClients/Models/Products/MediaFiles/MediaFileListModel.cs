using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Products.MediaFiles;

public class MediaFileList
{
    [JsonPropertyName("tenantId")]
    public Guid? TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    // [JsonPropertyName("id")]
    // public Guid Id { get; set; }

    // [JsonPropertyName("originalFileName")]
    // public string OriginalFileName { get; set; }

    /// <summary>
    /// File name after hashing.
    /// </summary>
    [JsonPropertyName("storageFileName")]
    public string StorageFileName { get; set; }

    /// <summary>
    /// File location 
    /// </summary>
    [JsonPropertyName("filePath")]
    public string FilePath { get; set; }

    /// <summary>
    /// Gets the raw Content-Disposition header of the uploaded file. 
    /// </summary>
    [JsonPropertyName("contentDisposition")]
    public string ContentDisposition { get; set; }

    /// <summary>
    /// Gets the raw Content-Type header of the uploaded file. 
    /// </summary>
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    /// <summary>
    /// Gets the file name from the Content-Disposition header.
    /// </summary>
    [JsonPropertyName("fileName")]
    public string FileName { get; set; }

    /// <summary>
    /// Gets the form field name from the Content-Disposition header.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("mediaFileType")]
    public int MediaFileType { get; set; }
}