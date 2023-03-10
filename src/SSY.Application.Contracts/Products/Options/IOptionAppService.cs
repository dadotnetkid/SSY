using SSY.Products.Options.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Options;

public interface IOptionAppService : ICrudAppService<OptionDto, int, PagedAndSortedResultRequestDto, CreateOptionDto, UpdateOptionDto>
{
}