using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Materials
{
    public class PackagingAndTrimAndAccessoriesListModel
    {
        public List<PackagingAndTrimAndAccessoriesModel> PackagingAndTrimAndAccessoriesList { get; set; }
        public PackagingAndTrimAndAccessoriesListModel()
        {
        }
    }
    public class PackagingAndTrimAndAccessoriesModel
    {

        [Required(ErrorMessage = "This field is required.")]
        public DateTime DateOfInventory { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        public string Stocktaker { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("validator")]
        public string Validator { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime SwatchSent { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime SwatchReceived { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        public string ConfirmedSwatchReceived { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string MaterialName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string MaterialType { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Color { get; set; }


        public double? Weight { get; set; } = null;

        public string WeightUnit { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public double ActualCount { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string UnitOfMeasurement { get; set; }


        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        public string BuildingWarehouse { get; set; } //

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Room { get; set; } //

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Rack { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string CompanyName { get; set; }

    }


}