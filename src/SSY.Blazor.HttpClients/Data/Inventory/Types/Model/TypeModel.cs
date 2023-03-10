using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Types.Model
{
    public partial class TypeModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int? OrderNumber { get; set; }

        [JsonPropertyName("categoryId")]
        public int CatergoryId { get; set; }

        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("counter")]
        public int Counter { get; set; } = 0;

        [JsonPropertyName("salesPercentage")]
        public double? SalesPercentage { get; set; }

        [JsonPropertyName("salesUnit")]
        public int SalesUnit { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }

        [JsonPropertyName("weightedSalesPercentage")]
        public int WeightedSalesPercentage { get; set; }

        [JsonPropertyName("weightedUnits")]
        public int WeightedUnits { get; set; }

        [JsonPropertyName("totalRequiredUnits")]
        public int TotalRequiredUnits { get; set; }

        [JsonPropertyName("totalPercentageUnits")]
        public int TotalPercentageUnits { get; set; }

        [JsonPropertyName("maxQuantity")]
        public int MaxQuantity { get; set; }

        [JsonPropertyName("units")]
        public double Units { get; set; }

        [JsonPropertyName("panels")]
        public List<PanelModel> Panels { get; set; } = new();

        [JsonPropertyName("panelIds")]
        public int? PanelIds { get; set; }

        public List<int> PanelIdList { get; set; } = new();

        public string SelectedPanels { get; set; }

        [JsonPropertyName("IsChecked")]
        public bool IsChecked { get; set; } = false;

        public List<int> CounterList { get; set; } = new();
        public void AddCounterList(int input)
        {
            CounterList.Add(input);
        }
    }

    public class TypeData
    {
        [JsonPropertyName("result")]
        public TypeResults Result { get; set; }

    }
    public class TypeResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<TypeModel> Items { get; set; }
    }
    public class TypeResult
    {
        [JsonPropertyName("result")]
        public TypeModel Result { get; set; }

    }

   


}


