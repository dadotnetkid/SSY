using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model
{
    public class UserDetailsOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }
    }
}

