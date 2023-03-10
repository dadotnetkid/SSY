using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationProductTypes.Model
{
    public class DeleteReservationProductTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

