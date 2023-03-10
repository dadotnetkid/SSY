using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model
{
    public class GetUserDetailOutputModel
    {
        [JsonPropertyName("result")]
        public UserDetailModel Result { get; set; } = new();
    }
}

