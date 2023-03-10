using SSY.Blazor.HttpClients.Data;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class GetReservationOutputModel
    {
        [JsonPropertyName("result")]
        public ReservationModel Result { get; set; } = new();

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}

