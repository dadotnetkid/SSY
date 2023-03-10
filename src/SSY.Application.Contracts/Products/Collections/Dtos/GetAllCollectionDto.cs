using System;
using System.Collections.Generic;
using SSY.Products.Collections.ColorOptions.Dtos;

namespace SSY.Products.Collections.Dtos
{
	public class GetAllCollectionDto
	{
	}

    public class GetAllCollectionListDto
    {
        public int TotalCount { get; set; }
        public List<CollectionListDto> Items { get; set; }
    }

    public class CollectionListDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string InfluencerNames { get; set; }
        public List<Guid> InfluencerIds { get; set; }
        public string DesignStatusValue { get; set; }
        public int ParentProductCount { get; set; }
        public int ChildProductCount { get; set; }
        public string StatusValue { get; set; }
        public DateTime DevelopmentStartDate { get; set; }
        public DateTime ProvisionalLaunchDate { get; set; }
        public bool Availability { get; set; }
        public List<CollectionColorOptionDto> ColorOptions { get; set; } = new();
    }

    public class CollectionColorOptionDto
    {
        public Guid ColorOptionId { get; set; }
        public Guid CollectionId { get; set; }
        public List<ColorOptionFabricDto> Fabrics { get; set; } = new();
    }
}

