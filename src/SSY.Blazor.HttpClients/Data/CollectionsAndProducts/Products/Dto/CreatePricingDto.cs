using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto
{
    public class CreatePricingDto
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("retailPrice")]
        public int RetailPrice { get; set; }

        [JsonPropertyName("shippingPremium")]
        public int ShippingPremium { get; set; }

        [JsonPropertyName("netPrice")]
        public int NetPrice { get; set; }
    }
}

