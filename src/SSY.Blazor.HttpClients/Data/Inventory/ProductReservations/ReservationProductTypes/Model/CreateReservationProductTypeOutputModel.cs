using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationProductTypes.Model
{
    public class CreateReservationProductTypeOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }

        [JsonPropertyName("error")]
        public ErrorMessageModel Error { get; set; }
    }
}

