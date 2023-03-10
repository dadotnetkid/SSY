using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationColors.Model
{
    public class DeleteReservationColorModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

