using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Settings.AutoEmails.Dtos;

public class DeleteAutoEmailDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}

