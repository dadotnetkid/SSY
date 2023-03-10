using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class SubMaterialAdjustmentModel
    {
        [Required]
        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; }

        [Required]
        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }

        [JsonPropertyName("buildingWarehouse")]
        public string? BuildingWarehouse { get; set; }

        [JsonPropertyName("tRackNumber")]
        public string? TRackNumber { get; set; }

        [JsonPropertyName("rack")]
        public string? Rack { get; set; }

        [JsonPropertyName("poNumber")]
        public string? PONumber { get; set; }

        [JsonPropertyName("shippedCount")]
        public double? ShippedCount { get; set; }

        [JsonPropertyName("receivedCount")]
        public double? ReceivedCount { get; set; }

        [Required]
        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

    }
}
