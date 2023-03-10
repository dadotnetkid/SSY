using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Services.IST.Models
{
    public class ExcessMarkApprovedMessage
    {
        [JsonPropertyName("isSuccess")]
        public int IsSuccess { get; set; }

        [JsonPropertyName("desc")]
        public string desc { get; set; }
    }
}

