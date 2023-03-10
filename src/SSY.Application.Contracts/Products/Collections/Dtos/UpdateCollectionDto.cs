using System;
using SSY.Products.Collections.AssignedTos.Dtos;
using SSY.Products.Collections.ColorOptions.Dtos;
using SSY.Products.Dtos;
using System.Collections.Generic;

namespace SSY.Products.Collections.Dtos;

public class UpdateCollectionDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public bool Availability { get; set; }
    public bool IsPublished { get; set; }
    public int Year { get; set; }
    public DateTime CollectionDevelopmentStartDate { get; set; }
    public DateTime ProvisionalLaunchDate { get; set; }

    public int SeasonId { get; set; }
    public int PricePointId { get; set; }
    public int FactoryId { get; set; }
    public int ShippingTypeId { get; set; }
    public int MarketingTypeId { get; set; }
    public int DesignStatusId { get; set; }
    public int StatusId { get; set; }
    public UpdateAssignedToDto AssignedTo { get; set; }

    /// <summary>
    /// TODO: Create ProductManager
    /// </summary>
    //public List<UpdateProductDto> Products { get; set; }
    public List<UpdateCollectionProductTypeDto> ProductTypes { get; set; }
    public List<UpdateCollectionInfluencerDto> Influencers { get; set; }
    /// <summary>
    /// TODO: Create ColorOptionManager
    /// </summary>
    public List<UpdateColorOptionDto> ColorOptions { get; set; }
    public List<UpdateCollectionSizeDto> Sizes { get; set; }

    public int CurrentFabricCount { get; set; }
}