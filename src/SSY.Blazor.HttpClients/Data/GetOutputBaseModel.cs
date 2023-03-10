using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data
{
    public class GetOutputBaseModel<TResult> where TResult : class
    {
        [JsonPropertyName("result")]
        public TResult Result { get; set; }

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}

