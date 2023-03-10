﻿using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Factories.Dtos;

public class FactoryDto : EntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
}