using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Materials
{

    public class InventoryData
    {
        [JsonPropertyName("result")]
        public InventoryResults Result { get; set; }
    }

    public class InventoryResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<InventoryModel> Items { get; set; }
    }

    public class InventoryResult
    {
        [JsonPropertyName("result")]
        public InventoryModel Result { get; set; }
    }

    public class InventoryModel
    {
        [Required]
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [Required]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonPropertyName("actualCount")]
        public double ActualCount { get; set; }

        [Required]
        [JsonPropertyName("unitOfMeasurementId")]
        public int UnitOfMeasurementId { get; set; }

        [JsonPropertyName("expectedCount")]
        public double? ExpectedCount { get; set; }

        [JsonPropertyName("reservedCount")]
        public double? ReservedCount { get; set; }

        [JsonPropertyName("availableCount")]
        public double? AvailableCount { get; set; }

        [JsonPropertyName("usedCount")]
        public double? UsedCount { get; set; }

        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [JsonPropertyName("mediaFileId")]
        public Guid? MediaFileId { get; set; }
    }
}