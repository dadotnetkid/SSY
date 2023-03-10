using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.OEM
{
    public class OEMModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("oEMid")]
        public string OEMId { get; set; }

        [JsonPropertyName("oEM")]
        public string OEM { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("contactPerson")]
        public string ContactPerson { get; set; }

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }


    }

}
