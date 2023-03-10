using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSY.Products.Types.Dtos;

public class UpdateTypeDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    /// <summary>
    /// MaterialType ForeignKey
    /// </summary>
    //[Required]
    public int MaterialTypeId { get; set; }

    /// <summary>
    /// Label
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Short Code
    /// </summary>
    [Required]
    public string ShortCode { get; set; }

    /// <summary>
    /// Order Number is use for sorting
    /// </summary>
    public int OrderNumber { get; set; }

    public double AverageConsumption { get; set; }
    public double? SalesPercentage { get; set; }
    public double? SubSalesPercentage { get; set; }

    public int? ProductCategoryId { get; set; }

    //public  ICollection<BaseSizeSpec> BaseSizeSpecs { get;  set; }
    //public  ICollection<OBJPatternBlock> OBJPatternBlocks { get;  set; }
    public List<UpdateTypeOptionDto> Options { get; set; }
    //public  ICollection<WorkmanshipGuide> WorkmanshipGuides { get;  set; }

    public double? FreeShippingFedExPrice { get; set; }
    public double? FreeShippingDHLPrice { get; set; }
    public double? TenUSDPrice { get; set; }
    public double? FifteenUSDPrice { get; set; }
    public double? TwentyUSDPrice { get; set; }
}