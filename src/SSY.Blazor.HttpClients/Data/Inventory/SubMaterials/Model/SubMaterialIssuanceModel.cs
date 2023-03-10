using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class SubMaterialIssuanceModel
    {
        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; }

        [JsonPropertyName("usage")]
        public double Usage { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

    }
}
