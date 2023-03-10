using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SampleImages.Model
{
    public class SampleImagesModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dateUpdated")]
        public string DateUpdated { get; set; }

        [JsonPropertyName("influencer")]
        public string Influencer { get; set; }

        [JsonPropertyName("designName")]
        public string DesignName { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("collection")]
        public string Collection { get; set; }

        [JsonPropertyName("ver")]
        public int Ver { get; set; }

        [JsonPropertyName("designer")]
        public string Designer { get; set; }

    }


}


