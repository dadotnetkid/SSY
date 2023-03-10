using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Model
{
    public class GetProductOptionsModel
    {
        [JsonPropertyName("result")]
        public ProductOptions Result { get; set; }
    }

    public class ProductOptions
    {
        [JsonPropertyName("gender")]
        public List<TypeOption> Gender { get; set; } = new();

        [JsonPropertyName("rise")]
        public List<TypeOption> Rise { get; set; } = new();

        [JsonPropertyName("waistband")]
        public List<TypeOption> Waistband { get; set; } = new();

        [JsonPropertyName("waistbandPocket")]
        public List<TypeOption> WaistbandPocket { get; set; } = new();

        [JsonPropertyName("frontSeam")]
        public List<TypeOption> FrontSeam { get; set; } = new();

        [JsonPropertyName("length")]
        public List<TypeOption> Length { get; set; } = new();

        [JsonPropertyName("panel")]
        public List<TypeOption> Panel { get; set; } = new();

        [JsonPropertyName("base")]
        public List<TypeOption> Base { get; set; } = new();

        [JsonPropertyName("neckline")]
        public List<TypeOption> Neckline { get; set; } = new();

        [JsonPropertyName("necklineStyle")]
        public List<TypeOption> NecklineStyle { get; set; } = new();

        [JsonPropertyName("backCutOutStyle")]
        public List<TypeOption> BackCutOutStyle { get; set; } = new();

        [JsonPropertyName("bustband")]
        public List<TypeOption> Bustband { get; set; } = new();

        [JsonPropertyName("bodyLength")]
        public List<TypeOption> BodyLength { get; set; } = new();

        [JsonPropertyName("fit")]
        public List<TypeOption> Fit { get; set; } = new();

        [JsonPropertyName("strap")]
        public List<TypeOption> Strap { get; set; } = new();

        [JsonPropertyName("sleeveType")]
        public List<TypeOption> SleeveType { get; set; } = new();

        [JsonPropertyName("sleeveStyle")]
        public List<TypeOption> SleeveStyle { get; set; } = new();

        [JsonPropertyName("hem")]
        public List<TypeOption> Hem { get; set; } = new();

        [JsonPropertyName("frontOpening")]
        public List<TypeOption> FrontOpening { get; set; } = new();

        [JsonPropertyName("pocket")]
        public List<TypeOption> Pocket { get; set; } = new();

        [JsonPropertyName("insideShorts")]
        public List<TypeOption> InsideShorts { get; set; } = new();

        [JsonPropertyName("legShape")]
        public List<TypeOption> LegShape { get; set; } = new();

        [JsonPropertyName("waistbandStyle")]
        public List<TypeOption> WaistbandStyle { get; set; } = new();

        [JsonPropertyName("insideShortLength")]
        public List<TypeOption> InsideShortLength { get; set; } = new();

        [JsonPropertyName("insideShortPanel")]
        public List<TypeOption> InsideShortPanel { get; set; } = new();

        [JsonPropertyName("outsideShorts")]
        public List<TypeOption> OutsideShorts { get; set; } = new();
    }

    public class TypeOption
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("parentId")]
        public int? ParentId { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("options")]
        public List<ChildTypeOption> Options { get; set; } = new();
    }

    public class ChildTypeOption
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("parentId")]
        public int? ParentId { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("options")]
        public List<ProductOptionDropdownModel> Options { get; set; } = new();
    }
}

