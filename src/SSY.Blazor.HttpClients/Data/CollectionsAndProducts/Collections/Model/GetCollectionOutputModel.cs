using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
	public class GetCollectionOutputModel
	{
        [JsonPropertyName("result")]
        public CollectionOutputModel Result { get; set; }
    }
}

