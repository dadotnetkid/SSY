using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class ColorOptionDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }
    public bool? IsDeleted { get; set; }

    public Guid CollectionId { get; set; }

    public string Title { get; set; }
    public int ColorId { get; set; }
    public string ColorShortCode { get; set; }
    public string ColorValue { get; set; }
    public int TypeId { get; set; }
   
    public bool? IsApproved { get; set; }
    public bool? IsRejected { get; set; }
    public DateTime? ApprovedOn { get; set; }
    public string ApprovedBy { get; set; }
    public List<ColorOptionProductTypeDto> ProductTypes { get; set; }
    public List<ColorOptionFabricDto> Fabrics { get; set; }
}