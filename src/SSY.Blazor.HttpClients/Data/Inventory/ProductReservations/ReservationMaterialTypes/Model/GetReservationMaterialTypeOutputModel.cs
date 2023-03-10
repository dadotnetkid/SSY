using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations.ReservationMaterialTypes.Model
{
    public class GetReservationMaterialTypeOutputModel
    {
        [JsonPropertyName("result")]
        public ReservationMaterialTypeModel Result { get; set; } = new();

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}

