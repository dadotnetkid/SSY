using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Materials
{


    public class OverviewData
    {
        [JsonPropertyName("result")]
        public OverviewResults Result { get; set; }

    }
    public class OverviewResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<OverviewModel> Items { get; set; }
    }
    public class OverviewResult
    {
        [JsonPropertyName("result")]
        public OverviewModel Result { get; set; }

    }

    public class OverviewModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("mediaFile")]
        public string MediaFile { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }



        // A.K.A. ColorGroupId
        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }
        public string ColorGroup { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }


        [JsonPropertyName("itemCode")]
        public string? ItemCode { get; set; }

        [JsonPropertyName("pantone")]
        public string? Pantone { get; set; }


        [JsonPropertyName("weight")]
        public double? Weight { get; set; }


        [JsonPropertyName("weightUnitId")]
        public int? WeightUnitId { get; set; }

        // Use to Generate MaterialName

        public string SupplierCode { get; set; }
        public string ExcessOrNew { get; set; }

    }


}


