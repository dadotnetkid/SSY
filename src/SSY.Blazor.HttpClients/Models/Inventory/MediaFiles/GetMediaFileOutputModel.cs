using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Inventory.MediaFiles;

public class GetMediaFileOutputModel
{
    [JsonPropertyName("result")]
    public MediaFileModel Result { get; set; }
}