using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.TimelineAndComments.Model.Comments
{
    public class CommentListModel
    {
        [JsonPropertyName("comments")]
        public List<CommentModel> Comments { get; set; } = new();
    }
}

