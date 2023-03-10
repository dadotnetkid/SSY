using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Authors;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}