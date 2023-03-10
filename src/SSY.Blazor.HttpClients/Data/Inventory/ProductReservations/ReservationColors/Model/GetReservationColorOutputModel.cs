using SSY.Blazor.HttpClients.Data;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationColors.Model
{
    public class GetReservationColorOutputModel
    {
        [JsonPropertyName("result")]
        public ReservationColorModel Result { get; set; } = new();

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}

