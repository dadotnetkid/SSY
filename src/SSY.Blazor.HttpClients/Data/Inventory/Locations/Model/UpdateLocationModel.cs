using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Locations.Model
{
    public class UpdateLocationModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;


        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("buildingWarehouse")]
        public string BuildingWarehouse { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("rack")]
        public string Rack { get; set; }
    }
}
