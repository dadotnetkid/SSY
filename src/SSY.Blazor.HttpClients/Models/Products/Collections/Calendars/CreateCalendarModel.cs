namespace SSY.Blazor.HttpClients.Models.Products.Collections.Calendars;

public class CreateCalendarModel
{
    public Guid Id { get; set; }
    public decimal ForecastQuantity { get; set; }
    public DateTime CollectionDevelopmentTarget { get; set; }
}