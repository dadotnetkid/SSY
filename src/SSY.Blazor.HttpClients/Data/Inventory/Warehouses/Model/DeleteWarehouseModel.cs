using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Warehouses.Model
{
    public class DeleteWarehouseModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}

