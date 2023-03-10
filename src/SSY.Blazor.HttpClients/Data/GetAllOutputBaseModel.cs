using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data
{
    public class GetAllOutputModelBase<TResult> where TResult : class
    {
        [JsonPropertyName("result")]
        public Results<TResult> Result { get; set; }

        [JsonPropertyName("error")]
        public virtual ErrorMessageModel ErrorMessage { get; set; }

        [JsonPropertyName("items")]
        public List<TResult> Items { get; set; }
    }
    public class GetOutputModelBase<TResult> where TResult : class
    {

        [JsonPropertyName("error")]
        public virtual ErrorMessageModel ErrorMessage { get; set; }

        [JsonPropertyName("result")]
        public List<TResult> Result { get; set; }
    }

    public class Results<TResult> where TResult : class
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("items")]
        public List<TResult> Items { get; set; }
    }
}

