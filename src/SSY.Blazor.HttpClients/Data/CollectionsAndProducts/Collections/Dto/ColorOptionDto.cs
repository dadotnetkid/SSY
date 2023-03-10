using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class ColorOptionDto
	{
		public ColorOptionDto()
		{
            ProductTypes = new();
            Fabrics = new();
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }


        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("colorShortCode")]
        public string ColorShortCode { get; set; }

        [JsonPropertyName("colorValue")]
        public string ColorValue { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }


        [JsonPropertyName("isApproved")]
        public bool? IsApproved { get; set; }

        [JsonPropertyName("isRejected")]
        public bool? IsRejected { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }

        [JsonPropertyName("productTypes")]
        public List<ColorOptionProductTypeDto> ProductTypes { get; set; }

        [JsonPropertyName("fabrics")]
        public List<ColorOptionFabricDto> Fabrics { get; set; }
    }
}

