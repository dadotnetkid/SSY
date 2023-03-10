using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Factories.Model
{
	public class FactoryListModel
	{
        [JsonPropertyName("factories")]
        public List<FactoryModel> Factories { get; set; } = new();
    }
}

