using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Assignments.Model
{
    public class GetAssignmentOutputModel
    {
        [JsonPropertyName("result")]
        public AssignmentModel Result { get; set; }
    }
}

