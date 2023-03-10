using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RevenueRelease.Model
{
    public class TransactionModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }

    }


}


