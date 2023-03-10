using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Timelines
{
    public class GetTimelineOutputModel
    {
        [JsonPropertyName("result")]
        public TimelineModel Result { get; set; } = new();
    }
}

