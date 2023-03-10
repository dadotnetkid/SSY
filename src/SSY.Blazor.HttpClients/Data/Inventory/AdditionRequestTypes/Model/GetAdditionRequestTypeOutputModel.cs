using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AdditionRequestTypes.Model
{
    public class GetAdditionRequestTypeOutputModel
    {
        [JsonPropertyName("result")]
        public AdditionRequestTypeModel Result { get; set; }
    }
}

