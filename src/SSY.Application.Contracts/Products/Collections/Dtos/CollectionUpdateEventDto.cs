using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.Dtos
{
    public class CollectionUpdateEventDto
    {
        public Guid CollectionId { get; }
        public int StatusId { get; }
        public decimal SalesForecastQuantity { get; }
        public DateTime CollectionDevelopmentTarget { get; }

        public CollectionUpdateEventDto(Guid collectionId, int statusId,decimal salesForecastQuantity,DateTime collectionDevelopmentTarget)
        {
            CollectionId = collectionId;
            StatusId = statusId;
            SalesForecastQuantity = salesForecastQuantity;
            CollectionDevelopmentTarget = collectionDevelopmentTarget;
        }
    }
}
