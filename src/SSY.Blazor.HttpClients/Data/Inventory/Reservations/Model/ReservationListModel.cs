using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class ReservationListModel
    {
        [JsonPropertyName("reservation")]
        public List<ReservationModel> Reservations { get; set; } = new();
    }
}

