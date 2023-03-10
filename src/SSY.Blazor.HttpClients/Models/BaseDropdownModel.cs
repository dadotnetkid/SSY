using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{
    // public class ColorListModel
    // {
    //     public List<ColorModel> ColorList { get; set; } = new();

    //     public ColorListModel()
    //     {


    //     }
    // }
    public class BaseDropdownModel
    {
        [JsonPropertyName("result")]
        public Results Result { get; set; }
    }

    public class ProductBaseDropdownModel
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<Items> Items { get; set; }
    }

    public class Results
    {
        [JsonPropertyName("items")]
        public List<Items> Items { get; set; }
    }

    public class Items
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("hexCode")]
        public string HexCode { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("salesPercentage")]
        public double? SalesPercentage { get; set; }

        [JsonPropertyName("subSalesPercentage")]
        public double SubSalesPercentage { get; set; }

        [JsonPropertyName("weightedSalesPercentage")]
        public double WeightedSalesPercentage { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }

        [JsonPropertyName("productCategoryId")]
        public int? ProductCategoryId { get; set; }

        [JsonPropertyName("weightedForecastQuantity")]
        public double WeightedForecastQuantity { get; set; }

        [JsonPropertyName("PFQTY")]
        public double PFQTY { get; set; }

        [JsonPropertyName("SummationPFQTY")]
        public double SummationPFQTY { get; set; }

        [JsonPropertyName("weightedFQAC")]
        public double WeightedFQAC { get; set; }

        [JsonPropertyName("requiredYardage")]
        public double RequiredYardage { get; set; }

        [JsonPropertyName("maxQuantityUnit")]
        public double MaxQuantityUnit { get; set; }

        [JsonPropertyName("IsOnEdit")]
        public bool IsOnEdit { get; set; } = false;

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; } = false;

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("colorWeightedSalesPercentage")]
        public double ColorWeightedSalesPercentage { get; set; }

        [JsonPropertyName("freeShippingFedExPrice")]
        public double FreeShippingFedExPrice { get; set; }

        [JsonPropertyName("freeShippingDHLPrice")]
        public double FreeShippingDHLPrice { get; set; }

        [JsonPropertyName("tenUSDPrice")]
        public double TenUSDPrice { get; set; }

        [JsonPropertyName("fifteenUSDPrice")]
        public double FifteenUSDPrice { get; set; }

        [JsonPropertyName("twentyUSDPrice")]
        public double TwentyUSDPrice { get; set; }
    }

    public class DropDownResult
    {
        [JsonPropertyName("result")]
        public Items Result { get; set; }

    }
}
