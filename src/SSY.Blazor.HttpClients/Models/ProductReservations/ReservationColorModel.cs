using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.ProductReservations
{
    public class ReservationColorModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("salesPercentage")]
        public double SalesPercentage { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }
    }
}
