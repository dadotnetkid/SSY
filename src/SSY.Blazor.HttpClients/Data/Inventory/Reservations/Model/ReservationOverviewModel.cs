using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class ReservationOverviewModel
    {
        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("wareHouse")]
        public string Warehouse { get; set; }

        [JsonPropertyName("reservedForCollection")]
        public double ReservedForCollection { get; set; }

        [JsonPropertyName("usedForCollectionCalculated")]
        public double UsedForCollectionCalculated { get; set; }

        [JsonPropertyName("usedForCollectionActual")]
        public double UsedForCollectionActual { get; set; }
    }
}

