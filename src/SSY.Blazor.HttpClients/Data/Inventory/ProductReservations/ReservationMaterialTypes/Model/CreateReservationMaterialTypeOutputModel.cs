using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model
{
    public class CreateReservationMaterialTypeOutputModel
    {
        [JsonPropertyName("result")]
        public Guid? Result { get; set; }

        [JsonPropertyName("error")]
        public ErrorMessageModel Error { get; set; }
    }
}

