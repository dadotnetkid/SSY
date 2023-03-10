using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories.Model
{
    public class CrudPurchasingHistoryOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }
    }
}

