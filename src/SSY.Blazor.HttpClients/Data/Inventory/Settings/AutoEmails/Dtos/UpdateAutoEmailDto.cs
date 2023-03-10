using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Settings.AutoEmails.Dtos;

public class UpdateAutoEmailDto
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("emailCategoryId")]
    public int EmailCategoryId { get; set; }

    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("cc")]
    public string Cc { get; set; }

    [JsonPropertyName("emailBody")]
    public string EmailBody { get; set; }
}