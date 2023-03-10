using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Assignments.Model
{
    public class CrudAssignmentOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }
    }
}

