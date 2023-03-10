using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.Inventory.InventoryAdditionRequests.Model
{
    public class InventoryAdditionRequestModel
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("colorGroupId")]
        public int ColorGroupId { get; set; }

        [JsonPropertyName("tCXCode")]
        public string TCXCode { get; set; }

        [JsonPropertyName("requiredYardage")]
        public double RequiredYardage { get; set; }
    }
}

