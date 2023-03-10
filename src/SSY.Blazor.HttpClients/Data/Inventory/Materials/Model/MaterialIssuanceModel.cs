using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class MaterialIssuanceModel
    {
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("rollNumber")]
        public string RollNumber { get; set; }

        [JsonPropertyName("usage")]
        public double Usage { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

    }
}
