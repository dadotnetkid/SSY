using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AccountInformation.Model
{
    public class ManualMeasurementModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("units")]
        public double Units { get; set; }

        [JsonPropertyName("hip")]
        public double Hip { get; set; }

        [JsonPropertyName("bust")]
        public double Bust { get; set; }

        [JsonPropertyName("waist")]
        public double Waist { get; set; }

        [JsonPropertyName("braSize")]
        public string BraSize { get; set; }

        [JsonPropertyName("braCupSize")]
        public string BraCupSize { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("heightUnits")]
        public string HeightUnits { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("weightUnits")]
        public string weightUnits { get; set; }

    }


}


