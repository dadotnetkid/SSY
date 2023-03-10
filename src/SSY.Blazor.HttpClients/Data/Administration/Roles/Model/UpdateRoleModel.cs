using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Roles.Model
{
    public class UpdateRoleModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}

