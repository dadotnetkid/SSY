using SSY.Blazor.HttpClients.Data;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class CreateReservationOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }

        [JsonPropertyName("error")]
        public ErrorMessageModel Error { get; set; }
    }
}

