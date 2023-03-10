using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Dtos;

public class CollectionTimelineDto : PagedAndSortedResultRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public List<CollectionTimelineItemDto> CollectionTimelineList { get; set; }
    public int CollectionTimelineListCount { get; set; }

    public CollectionTimelineDto()
    {
        CollectionTimelineList = new();
    }
}

public class CollectionTimelineItemDto
{
    public Guid Id { get; set; }
    public string InfluencerName { get; set; }
    public string CollectionName { get; set; }
}