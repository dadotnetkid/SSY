using System;
using SSY.Products.Collections.Seasons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.Seasons;

public interface ISeasonAppService : ICrudAppService<SeasonDto, int, PagedAndSortedResultRequestDto, CreateSeasonDto, UpdateSeasonDto>
{
}