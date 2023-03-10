using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

public class MediaFileListResult
{
    [JsonPropertyName("result")]
    public List<Guid> Ids { get; set; }
}