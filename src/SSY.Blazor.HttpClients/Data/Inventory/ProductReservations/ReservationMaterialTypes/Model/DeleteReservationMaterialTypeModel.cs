using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model
{
    public class DeleteReservationMaterialTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

