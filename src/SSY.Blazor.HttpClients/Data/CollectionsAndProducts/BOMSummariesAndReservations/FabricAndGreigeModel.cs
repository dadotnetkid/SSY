using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.BOMSummariesAndReservations
{
    public class FabricAndGreigeModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("colorName")]
        public string ColorName { get; set; }

        [JsonPropertyName("allocatedAmount")]
        public int AllocatedAmount { get; set; }

        [JsonPropertyName("remainingAllocatedSold")]
        public int RemainingAllocatedSold { get; set; }

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
        [JsonPropertyName("movedToReservationArea")]
        public string MovedToReservationArea { get; set; }

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
