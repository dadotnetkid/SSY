using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Factories.Model
{ 
    public class GetFactoryOutputModel
	{
        [JsonPropertyName("result")]
        public FactoryModel Result { get; set; } = new();
    }
}

