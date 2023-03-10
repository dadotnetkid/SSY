using System;
using SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
	public class CollectionColorOptionModel
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ColorId { get; set; }
        public int MaterialTypeId { get; set; }
        public Guid MaterialId { get; set; }
        public string HexCode { get; set; } = "#7B8E61";
        public int MaxQuantityUnit { get; set; }

        public List<MaterialModel> Fabrics { get; set; }
    }
}

