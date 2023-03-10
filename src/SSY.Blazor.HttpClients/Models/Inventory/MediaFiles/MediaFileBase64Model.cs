using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

public class MediaFileBase64Model
{
    [JsonPropertyName("result")]
    public string Result { get; set; }
}