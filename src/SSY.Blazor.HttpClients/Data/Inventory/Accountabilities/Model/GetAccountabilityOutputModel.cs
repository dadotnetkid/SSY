using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model
{
    public class GetAccountabilityOutputModel
    {
        [JsonPropertyName("result")]
        public AccountabilityModel Result { get; set; }
    }
}

