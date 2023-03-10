using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.WorkmanshipGuides.Model;

public class GetWorkmanshipGuideListOutputModel
{
    [JsonPropertyName("result")]
    public WorkmanshipGuideListModel Result { get; set; }
}

