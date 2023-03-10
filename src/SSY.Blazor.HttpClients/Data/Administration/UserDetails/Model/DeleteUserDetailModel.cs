using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model
{
    public class DeleteUserDetailModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}

