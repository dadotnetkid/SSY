using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.GeneratedMeasurements.Model
{
    public class GeneratedMeasurementsModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("aboveBustGirth")]
        public double AboveBustGirth { get; set; }

        [JsonPropertyName("waistGirth")]
        public double WaistGirth { get; set; }

        [JsonPropertyName("lowerWaistGirth")]
        public double LowerWaistGirth { get; set; }

        [JsonPropertyName("hipGirth")]
        public double HipGirth { get; set; }

        [JsonPropertyName("shoulderLength")]
        public double ShoulderLength { get; set; }

        [JsonPropertyName("neckGirth")]
        public double NeckGirth { get; set; }

        [JsonPropertyName("backWaistLength")]
        public double BackWaistLength { get; set; }

        [JsonPropertyName("lowWaistGirth")]
        public double LowWaistGirth { get; set; }

        [JsonPropertyName("armHoleGirth")]
        public double ArmHoleGirth { get; set; }

        [JsonPropertyName("armLength")]
        public double ArmLength { get; set; }

        [JsonPropertyName("kneeGirth")]
        public double KneeGirth { get; set; }

        [JsonPropertyName("calfGirth")]
        public double CalfGirth { get; set; }

        [JsonPropertyName("crotchLength")]
        public double CrotchLength { get; set; }

        [JsonPropertyName("sideSeam")]
        public double SideSeam { get; set; }

        [JsonPropertyName("inSeam")]
        public double InSeam { get; set; }

        [JsonPropertyName("acrossFont")]
        public double AcrossFont { get; set; }

        [JsonPropertyName("acrossBack")]
        public double AcrossBack { get; set; }

        [JsonPropertyName("inSeamAnkle")]
        public double InSeamAnkle { get; set; }

        [JsonPropertyName("chestWidth")]
        public double ChestWidth { get; set; }

        [JsonPropertyName("bustGirth")]
        public double BustGirth { get; set; }
    }


}


