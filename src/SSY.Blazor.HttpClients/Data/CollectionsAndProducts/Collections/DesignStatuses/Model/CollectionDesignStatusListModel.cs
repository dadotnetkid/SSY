using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;

public class CollectionDesignStatusListModel
{
    [JsonPropertyName("colletionDesignStatuses")]
    public List<CollectionDesignStatusModel> ColletionDesignStatuses { get; set; } = new();
}
