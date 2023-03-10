using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ContactPersons.Model
{
    public class ContactPersonListModel
    {
        [JsonPropertyName("items")]
        public List<ContactPersonModel> Items { get; set; }
    }
}

