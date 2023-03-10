using System;
using System.Collections.Generic;
using System.Text;
using SSY.Products.Collections.DesignStatuses.Dtos;

namespace SSY.Products.Collections.Calendars.Dtos
{
    public class GetCalendarCollectionDto
    {
        public string CollectionName { get; set; }
        public List<CollectionStatusDto> CollectionStatuses { get; set; } = new();
        public List<CollectionStatusDto> ActualCollectionStatus { get; set; } = new();
        public DateTime CollectionDevelopmentTarget { get; set; }
        public decimal ActualSalesQuantity { get; set; }
        public decimal SalesForecastQuantity { get; set; }
        public DateTime CollectionDevelopmentActual { get; set; }
    }

    public class CollectionStatusDto
    {
        public string Name { get; set; }
        public DateTime? Target { get; set; }
        public DateTime? Actual { get; set; }
        public CalendarProductStatusDto ProductStatus{ get; set; }
        public int TargetDay { get; set; }
    }
}
