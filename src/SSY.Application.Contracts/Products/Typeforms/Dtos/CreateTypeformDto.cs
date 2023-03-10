using System;

namespace SSY.Products.Typeforms.Dtos;

public class CreateTypeformDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Type { get; set; }
    public string Response { get; set; }
    public string Email { get; set; }
}