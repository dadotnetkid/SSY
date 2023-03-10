using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model
{
    public class CreateAdditionRequestOutputModel
    {
        [JsonPropertyName("result")]
        public AdditionRequestModel Result { get; set; }
    }
}

