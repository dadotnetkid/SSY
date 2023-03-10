using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data
{
    public class ErrorMessageModel
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("details")]
        public List<string> Details { get; set; }

        [JsonPropertyName("validationErrors")]
        public List<string> ValidationErrors { get; set; }
    }

    public class ErrorMessageOutputModel
    {
        [JsonPropertyName("error")]
        public ErrorMessageModel Error { get; set; }
    }
}

