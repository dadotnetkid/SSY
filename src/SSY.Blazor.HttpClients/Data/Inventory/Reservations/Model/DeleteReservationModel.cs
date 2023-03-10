using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class DeleteReservationModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}

