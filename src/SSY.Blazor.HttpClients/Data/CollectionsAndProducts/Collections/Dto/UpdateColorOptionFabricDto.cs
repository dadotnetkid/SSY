using System;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class UpdateColorOptionFabricDto
	{
        public UpdateColorOptionFabricDto()
        {
            Rolls = new();
        }

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }


        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("consumption")]
        public double? Consumption { get; set; }

        [JsonPropertyName("rolls")]
        public List<UpdateColorOptionFabricRollDto> Rolls { get; set; } = new();

        // For Shopify

        [JsonPropertyName("fabricComposition")]
        public string FabricComposition { get; set; }

        [JsonPropertyName("careInstruction")]
        public string CareInstruction { get; set; }

        // For Bill of Material

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("unitOfMeasurement")]
        public string UnitOfMeasurement { get; set; }

        [JsonPropertyName("cuttableWidth")]
        public string CuttableWidth { get; set; }

        [JsonPropertyName("contentDescription")]
        public string ContentDescription { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("supplier")]
        public string Supplier { get; set; }
    }
}

