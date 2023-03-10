﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Warehouses.Model
{
    public class CreateWarehouseModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [Required]
        [JsonPropertyName("maximumCapacity")]
        public double MaximumCapacity { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }
    }
}

