using System;

namespace SSY.Products.Collections.Calendars.Dtos;

public class AddCollectionToCalendarDto
{
    public Guid CollectionId { get; set; }
    public decimal SalesForecastQuantity { get; set; }
    public decimal ActualSalesQuantity { get; set; }
    public DateTime CollectionDevelopmentTarget { get; set; }
}