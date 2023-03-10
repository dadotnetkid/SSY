using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
	public class OutputModel
	{
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }
    }
}

