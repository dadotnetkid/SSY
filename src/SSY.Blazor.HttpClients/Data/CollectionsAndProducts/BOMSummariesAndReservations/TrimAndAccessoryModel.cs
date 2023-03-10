using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.BOMSummariesAndReservations
{
    public class TrimAndAccessoryModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; }

        [JsonPropertyName("colorName")]
        public string ColorName { get; set; }

        [JsonPropertyName("reservedCount")]
        public int ReservedCount { get; set; }

        [JsonPropertyName("remainingAllocatedAfterSold")]
        public int RemainingAllocatedAfterSold { get; set; }

        [JsonPropertyName("unallocatedSold")]
        public int UnallocatedSold { get; set; }

        [JsonPropertyName("unitOfMeasurements")]
        public string UnitOfMeasurements { get; set; }

        [JsonPropertyName("consumption")]
        public string Consumption { get; set; }

        [JsonPropertyName("maxQtyUsingPlusAllocated")]
        public int MaxQtyUsingPlusAllocated { get; set; }

        [JsonPropertyName("maxQtyUsingMinusAllocated")]
        public int MaxQtyUsingMinusAllocated { get; set; }

        [JsonPropertyName("usedInProducts")]
        public string usedInProducts { get; set; }

        /////////////////////
        //Physical Location//
        /////////////////////
        [JsonPropertyName("reserved")]
        public string Reserved { get; set; }

        [JsonPropertyName("physicalMovedBy")]
        public string PhysicalMovedBy { get; set; }

        [JsonPropertyName("movedDate")]
        public DateTime movedDate { get; set; }

        [JsonPropertyName("currentLocation")]
        public string CurrentLocation { get; set; }
        /////////////////////////
        //End Physical Location//
        /////////////////////////

        /////////////////////
        ///Excess Returned///
        /////////////////////
        [JsonPropertyName("excessAmount")]
        public string excessAmount { get; set; }

        [JsonPropertyName("excessReturned")]
        public string ExcessReturned { get; set; }

        [JsonPropertyName("excessMovedBy")]
        public string ExcessMovedBy { get; set; }

        [JsonPropertyName("movedDate")]
        public string MovedDate { get; set; }
        ///////////////////////
        //End Excess Returned//
        ///////////////////////

    }


}
