using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Materials
{
    public class TrimsAndAccesorries
    {

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("file")]
        public string File { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("dateInventory")]
        public string DateOfInventory { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        //date missing  
        [JsonPropertyName("stocktaker")]
        public string Stocktaker { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("validator")]
        public string validator { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("swatchSent")]
        //date missing
        public string SwatchSent { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("swatchRecieved")]
        //date missing
        public string SwatchRecieved { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("confirmedSwatchSent")]
        public string ConfirmedSwatchSent { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("imagesFilename")]
        public string ImagesFilename { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("materialType")]
        public string MaterialType { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("colorName")]
        public string ColorName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("codeColor")]
        public string CodeColor { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }


        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("pantoneNumber")]
        public string PantoneNumber { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("weightUnit")]
        public string WeightUnit { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("actualCount")]
        public string ActualCount { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("unitMeasurement")]
        public string UnitOfMeasurement { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("rollNumber")]
        public string RollNumber { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("dateAcquired")]
        public string DateAcquired { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("shelfLife")]
        public string Shelflife { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("shading")]
        public string Shading { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("buildingWarehouse")]
        public string BuildingWarehouse { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("room")]
        public string Room { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("rack")]
        public string Rack { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("construction")]
        public string Construction { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("gauge")]
        public string Gauge { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("recycled")]
        public string Recycled { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("excess")]
        public string Excess { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("pfp")]
        public string PFP { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("compression")]
        public string Compression { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("fabricStretch")]
        public string FabricStretch { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("crease")]
        public string Crease { get; set; }

        [JsonPropertyName("printRepeat")]
        public string PrintRepeat { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("careinstructionType")]
        public string CareInstructionType { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

    }


}