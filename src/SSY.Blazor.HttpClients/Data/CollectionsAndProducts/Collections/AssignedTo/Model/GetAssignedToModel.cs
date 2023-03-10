using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model
{
    public class GetAssignedToModel
    {
        [JsonPropertyName("result")]
        public AssignedToModel Result { get; set; }
    }
}

