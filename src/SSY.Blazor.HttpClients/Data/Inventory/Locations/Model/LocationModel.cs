using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Locations.Model
{
    public class LocationModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("buildingWarehouse")]
        public string BuildingWarehouse { get; set; }

        [JsonPropertyName("room")]
        [Required(ErrorMessage = "This field is required.")]
        public string Room { get; set; }

        [JsonPropertyName("rack")]
        [Required(ErrorMessage = "This field is required.")]
        public string Rack { get; set; }

        public LocationModel()
        {
        }
    }
}
