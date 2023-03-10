﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model;

public class UpdateExcessListModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

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