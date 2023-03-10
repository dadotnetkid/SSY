using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using SSY.Products.Collections.Seasons.Dtos;
using SSY.Products.Collections.PricePoints.Dtos;
using SSY.Products.Collections.Factories.Dtos;
using SSY.Products.Collections.ShippingTypes.Dtos;
using SSY.Products.Collections.AssignedTos.Dtos;
using SSY.Products.Collections.Statuses.Dtos;
using SSY.Products.Dtos;
using SSY.Products.Collections.ColorOptions.Dtos;
using SSY.Products.Collections.MarketingTypes.Dtos;
using SSY.Products.Collections.DesignStatuses.Dtos;
using System.Text.Json;

namespace SSY.Products.Collections.Dtos;

public class CollectionDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public bool Availability { get; set; }
    public bool IsPublished { get; set; }
    public int Year { get; set; }
    public DateTime CollectionDevelopmentStartDate { get; set; }
    public DateTime ProvisionalLaunchDate { get; set; }

    public SeasonDto Season { get; set; }

    public PricePointDto PricePoint { get; set; }

    public FactoryDto Factory { get; set; }

    public ShippingTypeDto ShippingType { get; set; }

    public MarketingTypeDto MarketingType { get; set; }

    public DesignStatusDto DesignStatus { get; set; }

    public AssignedToDto AssignedTo { get; set; }

    public StatusDto Status { get; set; }

    public List<ProductDto> Products { get; set; }
    public List<CollectionProductTypeDto> ProductTypes { get; set; }
    public string InfluencerNames { get {
            string names = string.Empty;
            Influencers.ForEach(x => names = string.Join(", ", x.InfluencerFullName));
            return names; } }
    public List<CollectionInfluencerDto> Influencers { get; set; }
    public List<ColorOptionDto> ColorOptions { get; set; }
    public List<CollectionSizeDto> Sizes { get; set; }

    public DateTime CreationTime { get; set; }


}