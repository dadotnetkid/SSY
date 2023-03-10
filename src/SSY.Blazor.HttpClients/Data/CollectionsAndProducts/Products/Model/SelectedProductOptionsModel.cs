using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;

public class SelectedProductOptionsModel
{
    [JsonPropertyName("optionId")]
    public int OptionId { get; set; }

    [JsonPropertyName("mainMotherId")]
    public int? MainMotherId { get; set; }

    [JsonPropertyName("parentId")]
    public int? ParentId { get; set; }

    [JsonPropertyName("optionLabel")]
    public string Label { get; set; }

    [JsonPropertyName("optionValue")]
    public string Value { get; set; }

    [JsonPropertyName("options")]
    public SelectedProductOptionsModel Options { get; set; }
}