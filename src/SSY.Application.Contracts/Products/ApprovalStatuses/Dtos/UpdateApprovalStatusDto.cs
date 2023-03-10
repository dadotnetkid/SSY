﻿using System;

namespace SSY.Products.ApprovalStatuses.Dtos;

public class UpdateApprovalStatusDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
}