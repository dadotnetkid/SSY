using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model
{
    public class RevenueReleaseModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("totalSales")]
        public double TotalSales { get; set; }

        [JsonPropertyName("yourRevenue")]
        public double YourRevenue { get; set; }

        [JsonPropertyName("totalRevenueReleased")]
        public double TotalRevenueReleased { get; set; }

        [JsonPropertyName("totalAvailableForRelease")]
        public double TotalAvailableForRelease { get; set; }

        [JsonPropertyName("revenuePendingRelease")]
        public double RevenuePendingRelease { get; set; }

    }


}


