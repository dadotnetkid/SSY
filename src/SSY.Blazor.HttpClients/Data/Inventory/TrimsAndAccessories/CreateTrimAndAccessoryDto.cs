using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.TrimsAndAccessories
{
    public class CreateTrimAndAccessoryDto
    {
        #region Overview

        [Required(ErrorMessage = "This Image field is required.")]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This Category ID is required.")]
        [JsonPropertyName("category")]
        public int Category { get; set; }

        //[Required(ErrorMessage = "This Material Name is required.")]
        [JsonPropertyName("materialname")]
        public string MaterialName { get; set; }

        //[Required(ErrorMessage = "This Material Type ID is required.")]
        [JsonPropertyName("materialnTypeId)]")]
        public string MaterialTypeId { get; set; }

        //[Required(ErrorMessage = "This Color ID field is required.")]
        [JsonPropertyName("colorId")]
        public string ColorId { get; set; }

        //[Required(ErrorMessage = "This Weight field is required.")]
        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        //[Required(ErrorMessage = "This Weight Unit ID field is required.")]
        [JsonPropertyName("weightUnitId")]
        public string WeightUnitId { get; set; }

        #endregion



        #region Accountability

        //[Required(ErrorMessage = "This Accountability ID field is required.")]
        [JsonPropertyName("accountabilityId")]
        public Guid AccountabilityId { get; set; }

        #endregion



        #region Inventory

        [Required(ErrorMessage = "This Actual Count field is required.")]
        [JsonPropertyName("actualCount")]
        public string ActualCount { get; set; }

        [Required(ErrorMessage = "This Unit of Measurement field is required.")]
        [JsonPropertyName("unitOfMeasurementId")]
        public int UnitOfMeasurementId { get; set; }

        [JsonPropertyName("minimumStockLevel")]
        public double MinimumStockLevel { get; set; }

        [JsonPropertyName("expectedCount")]
        public int ExpectedCount { get; set; }

        [JsonPropertyName("reservedCount")]
        public int ReservedCount { get; set; }

        [JsonPropertyName("availableCount")]
        public int AvailableCount { get; set; }

        [JsonPropertyName("usedCount")]
        public int UsedCount { get; set; }

        #endregion



        #region Roll And Location

        [JsonPropertyName("rollsAndLocations")]
        public List<RollAndLocationModel> RollsAndLocations { get; set; }

        #endregion




        #region Supplier

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("companyId")]
        public Guid CompanyId { get; set; }

        #endregion
    }
}
