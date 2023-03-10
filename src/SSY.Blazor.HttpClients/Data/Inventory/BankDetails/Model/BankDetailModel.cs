using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.BankDetails.Model
{
    public class BankDetailModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("beneficiaryName")]
        public string BeneficiaryName { get; set; }

        [JsonPropertyName("beneficiaryAddress")]
        public string BeneficiaryAddress { get; set; }

        [JsonPropertyName("beneficiaryBank")]
        public string BeneficiaryBank { get; set; }

        [JsonPropertyName("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [JsonPropertyName("swiftCode")]
        public string SwiftCode { get; set; }

        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonPropertyName("payPalEmail")]
        public string PayPalEmail { get; set; }
    }


}


