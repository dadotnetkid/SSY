using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Roles.Model
{
    public class GetRoleOutputModel
    {
        [JsonPropertyName("result")]
        public RoleModel Result { get; set; }
    }
}

