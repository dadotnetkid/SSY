using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Products.Collections.Calendars;

public class CalendarCollectionModel
{
    public string CollectionName { get; set; }
    public decimal ActualSalesQuantity { get; set; }
    public decimal SalesForecastQuantity { get; set; }
    public List<CollectionStatusModel> CollectionStatuses { get; set; } = new();
    public List<CollectionStatusModel> ActualCollectionStatus { get; set; } = new();
    public DateTime CollectionDevelopmentTarget { get; set; }
    public DateTime CollectionDevelopmentActual { get; set; }
}

public partial class CollectionStatusModel
{
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("orderNumber")]
    public int OrderNumber { get; set; }
    public string Name { get; set; }
    public DateTime? Target { get; set; }
    public DateTime? Actual { get; set; }
    public CalendarProductStatusModel ProductStatus { get; set; }
    public int TargetDay { get; set; }
}

public class CalendarDesignStatusModel
{
    public int Id { get; set; }
    public string Label { get; set; }
}
public class CalendarProductStatusModel
{
    public int Id { get; set; }
    public string Label { get; set; }
    public CalendarDesignStatusModel DesignStatus { get; set; }
}