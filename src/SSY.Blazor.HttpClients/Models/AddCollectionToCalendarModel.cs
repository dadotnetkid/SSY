namespace SSY.Web.Blazor.PageModels.Collections
{
    public class AddCollectionToCalendarModel
    {
        public Guid CollectionId { get; set; }
        public decimal SalesForecastQuantity { get; set; }
        public decimal ActualSalesQuantity { get; set; }
        public DateTime CollectionDevelopmentTarget { get; set; }
    }

    public class UpdateCollectionCalendarModel
    {
        public Guid CollectionId { get; }
        public int StatusId { get; }
        public decimal SalesForecastQuantity { get; }
        public DateTime CollectionDevelopmentTarget { get; }

        public UpdateCollectionCalendarModel(Guid collectionId, int statusId, decimal salesForecastQuantity, DateTime collectionDevelopmentTarget)
        {
            CollectionId = collectionId;
            StatusId = statusId;
            SalesForecastQuantity = salesForecastQuantity;
            CollectionDevelopmentTarget = collectionDevelopmentTarget;
        }
    }

}
