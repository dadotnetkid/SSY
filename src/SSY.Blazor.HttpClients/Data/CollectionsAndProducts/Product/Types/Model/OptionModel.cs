using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Types.Model
{
    public class OptionModel
    {
        [JsonPropertyName("optionId")]
        public int Id { get; set; }

        [JsonPropertyName("optionParentId")]
        public int? ParentId { get; set; }

        [JsonPropertyName("optionLabel")]
        public string Label { get; set; }

        [JsonPropertyName("optionValue")]
        public string Value { get; set; }

        [JsonPropertyName("optionHasPanel")]
        public bool HasPanel { get; set; }

        [JsonPropertyName("optionOptions")]
        public List<OptionOptionsModel> OptionOptions { get; set; } = new();

    }

    public class OptionOptionsModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("parentId")]
        public int? ParentId { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("hasPanel")]
        public bool HasPanel { get; set; }

        [JsonPropertyName("options")]
        public List<OptionOptionsModel> OptionOptions { get; set; }

    }
}

