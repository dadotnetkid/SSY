using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.Dtos;

public class CreateCollectionInfluencerDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid CollectionId { get; set; }
    public Guid InfluencerId { get; set; }
    public string InfluencerFullName { get; set; }
    public string InfluencerName { get; set; }
    public string InfluencerSurname { get; set; }
}