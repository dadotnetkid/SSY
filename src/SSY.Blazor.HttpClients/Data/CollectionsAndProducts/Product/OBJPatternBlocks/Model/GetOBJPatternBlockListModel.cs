using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.OBJPatternBlocks.Model;

public class GetOBJPatternBlockListModel
{
    [JsonPropertyName("result")]
    public OBJPatternBlockListModel Result { get; set; }
}

