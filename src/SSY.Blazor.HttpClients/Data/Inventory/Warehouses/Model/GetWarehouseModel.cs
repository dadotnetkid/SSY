using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Warehouses.Model
{
    public class GetWarehouseModel
    {
        [JsonPropertyName("result")]
        public WarehouseModel Result { get; set; }
    }
}

