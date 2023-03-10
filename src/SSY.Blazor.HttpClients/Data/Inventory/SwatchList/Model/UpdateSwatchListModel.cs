﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.SwatchList.Model;

public class UpdateSwatchListModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("isReceived")]
    public bool IsReceived { get; set; } = true;

    [JsonPropertyName("companyId")]
    public int CompanyId { get; set; }

    [JsonPropertyName("accountabilityId")]
    public Guid MediaFileId { get; set; }

    [JsonPropertyName("accountability")]
    public MediaFileModel MediaFile { get; set; } = new();

    [Required]
    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }
}