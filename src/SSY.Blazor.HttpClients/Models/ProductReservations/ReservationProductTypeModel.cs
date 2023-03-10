using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.ProductReservations
{
    public class ReservationProductTypeModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("salesPercentage")]
        public double SalesPercentage { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }

        [JsonPropertyName("productCategoryId")]
        public int ProductCategoryId { get; set; }

        [JsonPropertyName("subSalesPercentage")]
        public double SubSalesPercentage { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }
    }
}
