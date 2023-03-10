using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Companies.Model
{
    public class CompanyMaterialTypeKeysModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }
    }
}

