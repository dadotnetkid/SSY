using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Users.Model
{
    public class GetUserOutputModel
    {
        [JsonPropertyName("result")]
        public UserModel Result { get; set; }
    }
}

