using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;


public class PurchaseOrderWithRollsModelResults
{
    [JsonPropertyName("result")]
    public List<PurchaseOrderWithRollsModel> Result { get; set; } = new();
}

public class PurchaseOrderWithRollsModel
{
    [JsonPropertyName("itemCode")]
    public string ItemCode { get; set; }

    [JsonPropertyName("colorCode")]
    public string ColorCode { get; set; }

    [JsonPropertyName("colorGroup")]
    public string ColorGroup { get; set; }

    [JsonPropertyName("roll")]
    public RollAndLocationModel Roll { get; set; } = new();

    [JsonPropertyName("isReceived")]
    public bool IsReceived { get; set; }
}

