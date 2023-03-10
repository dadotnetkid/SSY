using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Users.Model
{
    public class UserSession
    {
        public UserSession()
        {
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("authentication_token")]
        public string Token { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

    }
}
