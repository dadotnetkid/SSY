using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;

public class CollectionStatusListModel
{
    [JsonPropertyName("colletionStatuses")]
    public List<CollectionStatusModel> ColletionStatuses { get; set; } = new();
}
