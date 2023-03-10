using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Comments
{
    public class GetCommentOutputModel
    {
        [JsonPropertyName("result")]
        public CommentModel Result { get; set; } = new();
    }
}

