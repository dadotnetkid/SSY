using System;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;

public class ReceivedPurchaseOrderModel
{
    //List ng Roll and Location
    public List<RollAndLocationModel> Rolls { get; set; } = new();
    //List ng Submaterial Model
    public List<SubMaterialModel> SubMaterials { get; set; } = new();

}

