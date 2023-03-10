using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model
{
    public class CollectionReviewModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("collecitonName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("launchDate")]
        public string LaunchDate { get; set; }

        [JsonPropertyName("totalSales")]
        public double TotalSales { get; set; }

        [JsonPropertyName("refunds")]
        public double Refunds { get; set; }

        [JsonPropertyName("netSales")]
        public double NetSales { get; set; }

        [JsonPropertyName("revenue")]
        public double Revenue { get; set; }

    }


}


