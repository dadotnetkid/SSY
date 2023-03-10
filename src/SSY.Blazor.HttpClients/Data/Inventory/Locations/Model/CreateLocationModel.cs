using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Locations.Model
{
    public class CreateLocationModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;


        [JsonPropertyName("buildingWarehouse")]
        public string BuildingWarehouse { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("rack")]
        public string Rack { get; set; }

        public CreateLocationModel()
        {
        }
    }
}
