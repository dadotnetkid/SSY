using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationProductTypes.Model
{
    public class GetReservationProductTypeOutputModel
    {
        [JsonPropertyName("result")]
        public ReservationProductTypeModel Result { get; set; } = new();

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}

