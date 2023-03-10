using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Shopifies.Dtos
{
    public class ShopifyOnPublishEvent
    {
        public long? ShopifyId { get; set; }
        public Guid ProductId { get; set; }
        public DateTimeOffset? PublishedAt { get; set; }
        public string Name { get; set; }
        public long? VariantId { get; set; }
    }
    public class ShopifyOnPublishCollectionEvent
    {
        public long? ShopifyId { get; set; }
        public Guid CollectionId { get; set; }
        public DateTimeOffset? PublishedAt { get; set; }
        public string Name { get; set; }
    }
}
