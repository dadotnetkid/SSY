using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Influencers.Model
{
    public class GetInfluencerInputModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

