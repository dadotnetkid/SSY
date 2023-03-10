using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Options;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Shopifies
{
    public class Shopify : Entity<Guid>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual Guid? ProductId { get; protected set; }
        public virtual Product Product { get; protected set; }

        public virtual bool Published { get; protected set; }
        public virtual DateTime PublishedAt { get; protected set; }
        /// <summary>
        /// Shopify Id for UI
        /// </summary>
        public virtual string Number { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual string FabricComposition { get; protected set; }
        public virtual string CareInstruction { get; protected set; }

        /// <summary>
        /// List of strings.
        /// </summary>
        public virtual string Tags { get; protected set; }
        public virtual string Description { get; protected set; }

        public long? ShopifyId { get; set; }
        public long? VariantId { get; set; }
        public virtual ICollection<ShopifyMediaFile> MediaFiles { get; protected set; }

        protected Shopify()
        {
            MediaFiles = new Collection<ShopifyMediaFile>();
        }

        public Shopify(bool isActive, Guid? productId, bool published, DateTimeOffset? publishedAt, string number, string name, double? price, string fabricComposition, string careInstruction, string tags, string description, long? shopifyId)
        {
            IsActive = isActive;
            ProductId = productId;
            Published = published;
            PublishedAt = publishedAt?.DateTime ?? DateTime.Now;
            Number = number;
            Name = name;
            Price = price??0;
            FabricComposition = fabricComposition;
            CareInstruction = careInstruction;
            Tags = tags;
            Description = description;
        }

        public virtual void AddMediaFiles(List<ShopifyMediaFile> mediaFiles)
        {
            mediaFiles.ForEach(mediaFile =>
            {
                MediaFiles.Add(mediaFile);
            });
        }

        public virtual void ClearMediaFiles()
        {
            MediaFiles.Clear();
        }

        public void SetShopifyId(long? shopifyId)
        {
            this.ShopifyId = shopifyId;
        }
        public void SetVariantId(long? variantId)
        {
            this.VariantId=variantId;   
        }

        public void SetPublished(bool published)
        {
            Published = published;
        }

        public void SetPublishedAt(DateTime publishedAt)
        {
            PublishedAt = publishedAt;
        }

        

        
    }
}