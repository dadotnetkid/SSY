using SSY.Blazor.HttpClients.Data;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationColors.Model
{
    public class CreateReservationColorOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }

        [JsonPropertyName("error")]
        public ErrorMessageModel Error { get; set; }
    }
}

