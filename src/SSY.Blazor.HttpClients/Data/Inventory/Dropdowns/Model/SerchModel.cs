using System;
namespace SSY.Blazor.HttpClients.Data.Inventory.Dropdowns.Model
{
    public class SearchModel
    {
        public int? ColorId { get; set; } = default;
        public int? MaterialTypeId { get; set; } = default;
        public int? CompositionId { get; set; } = default;

        public int? InfluencerId { get; set; } = default;

        public string? WarehouseLocation { get; set; } = default;
    }
}

