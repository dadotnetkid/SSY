using System;
using System.Collections.Generic;

namespace SSY.Products.Collections.ColorOptions.Dtos
{
	public class CreateColorOptionFabricDto
	{
        public Guid? TenantId { get; set; }
        public bool IsActive { get; set; }

        public Guid ColorOptionId { get; set; }

        public Guid MaterialId { get; set; }
        public double? Consumption { get; set; }

        public List<CreateColorOptionFabricRollDto> Rolls { get; set; }

        // For Shopify

        public string FabricComposition { get; set; }
        public string CareInstruction { get; set; }

        // For Bill of Material

        public string ColorCode { get; set; }
        public string ItemCode { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CuttableWidth { get; set; }
        public string ContentDescription { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
    }
}

