using System;

namespace SSY.Products.Typeforms.Dtos;

public class UpdateTypeformDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Type { get; set; }
    public string Response { get; set; }
}