using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model
{
    public class ReservationMaterialTypeModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }


        [JsonPropertyName("salesPercentage")]
        public double SalesPercentage { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

    }
}