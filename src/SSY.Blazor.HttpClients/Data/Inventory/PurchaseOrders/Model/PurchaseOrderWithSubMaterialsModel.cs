using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;


public class PurchaseOrderWithSubMaterialsModel
{

    [JsonPropertyName("result")]
    public List<SubMaterialModel> Result { get; set; } = new();

}

