using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Sales.Model
{
    public class SaleModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("orders")]
        public double Orders { get; set; }

        [JsonPropertyName("netItems")]
        public double NetItems { get; set; }

        [JsonPropertyName("sales")]
        public double Sales { get; set; }

        [JsonPropertyName("salesReturn")]
        public double SalesReturn { get; set; }

    }


}


