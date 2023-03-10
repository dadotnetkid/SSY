using System;
namespace SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model
{
    public class UpdateAccountabilityModel
    {
        public Guid Id { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public DateTime DateOfInventory { get; set; }
        public string StockTaker { get; set; }
        public string Validator { get; set; }
        public DateTime SwatchSent { get; set; }
        public DateTime SwatchRecieved { get; set; }
        public string ConfirmedSwatchRecieved { get; set; }
    }
}
