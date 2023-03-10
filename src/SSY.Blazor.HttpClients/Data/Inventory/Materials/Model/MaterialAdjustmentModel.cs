using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;

public class MaterialAdjustmentModel
{
    [Required]
    [JsonPropertyName("itemCode")]
    public string ItemCode { get; set; }

    [Required]
    [JsonPropertyName("colorCode")]
    public string ColorCode { get; set; }

    [Required]
    [JsonPropertyName("rollNumber")]
    public string RollNumber { get; set; }

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

