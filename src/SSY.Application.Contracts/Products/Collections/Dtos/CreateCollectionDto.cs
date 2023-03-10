using System;
using SSY.Products.Collections.AssignedTos.Dtos;
using SSY.Products.Collections.ColorOptions.Dtos;
using SSY.Products.Collections.DesignStatuses.Dtos;
using SSY.Products.Collections.Factories.Dtos;
using SSY.Products.Collections.MarketingTypes.Dtos;
using SSY.Products.Collections.PricePoints.Dtos;
using SSY.Products.Collections.Seasons.Dtos;
using SSY.Products.Collections.ShippingTypes.Dtos;
using SSY.Products.Dtos;
using System.Collections.Generic;
using SSY.Products.Collections.Statuses.Dtos;

namespace SSY.Products.Collections.Dtos;

public class CreateCollectionDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public int Year { get; set; }
    public int SeasonId { get; set; }
    public int PricePointId { get; set; }
    public int FactoryId { get; set; }
    public int ShippingTypeId { get; set; }
    public int MarketingTypeId { get; set; }
    public int DesignStatusId { get; set; }
    public int StatusId { get; set; }

    public CreateAssignedToDto AssignedTo { get; set; } = new();

    /// <summary>
    /// TODO: Create ProductManager
    /// </summary>
    //public List<CreateProductDto> Products { get; set; }
    public List<CreateCollectionProductTypeDto> ProductTypes { get; set; }
    public List<CreateCollectionInfluencerDto> Influencers { get; set; }
    /// <summary>
    /// TODO: Create ColorOptionManager
    /// </summary>
    public List<CreateColorOptionDto> ColorOptions { get; set; }

    public List<CreateCollectionSizeDto> Sizes { get; set; } = new();
}