using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ContactPersons.Model
{
    public class GetContactPersonOutputModel
    {
        [JsonPropertyName("result")]
        public ContactPersonModel Result { get; set; }
    }
}

