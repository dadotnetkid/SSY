using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Settings.AutoEmails.Dtos
{
    public class GetAutoEmailDto
    {
        [JsonPropertyName("result")]
        public AutoEmailDto Result { get; set; }
    }
}

