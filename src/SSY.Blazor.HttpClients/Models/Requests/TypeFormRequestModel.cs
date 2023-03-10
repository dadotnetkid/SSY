using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SSY.Blazor.HttpClients.Models.Requests
{
    public class TypeFormRequestModel
    {
        [JsonProperty("type"), JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonProperty("email"), JsonPropertyName("email")]
        public List<string> Email { get; set; }
    }
}
