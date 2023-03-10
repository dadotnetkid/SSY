using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Products.Collections.CalendarConfigurations
{
    public class CalendarConfigurationModel
    {
        [JsonPropertyName("tenantId")]
        public object TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productStatusId")]
        public int ProductStatusId { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
