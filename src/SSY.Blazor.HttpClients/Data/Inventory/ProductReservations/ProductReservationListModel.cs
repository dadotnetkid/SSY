namespace SSY.Blazor.HttpClients.Data.Inventory.ProductReservations
{
    public class ProductReservationListModel
    {
        public List<ProductReservationModel> ProductReservations { get; set; } = new();
        public List<ReservationColorModel> ReservationColors { get; set; } = new();
        public List<ReservationMaterialTypeModel> ReservationMaterialTypes { get; set; } = new();
        public List<ReservationProductTypeModel> ReservationProductTypes { get; set; } = new();

    }
}

