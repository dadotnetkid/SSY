using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model
{
    public class PurchaseOrderISTModelResults
    {
        [JsonPropertyName("result")]
        public List<PurchaseOrderISTModel> Result { get; set; } = new();
    }

    public class PurchaseOrderISTModel
    {

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("poNumber")]
        public string PONumber { get; set; }
    }
}

