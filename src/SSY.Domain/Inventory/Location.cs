using System;


namespace SSY.Inventory
{
    [Table("AppLocations")]
    public class Location : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }


        [Required(ErrorMessage = "This BuildingWarehouse field is required")]
        public string BuildingWarehouse { get; set; }

        [Required(ErrorMessage = "This Room field is required")]
        public string Room { get; set; }

        [Required(ErrorMessage = "This Rack field is required")]
        public string Rack { get; set; }

        public Location()
        {
        }
    }
}
