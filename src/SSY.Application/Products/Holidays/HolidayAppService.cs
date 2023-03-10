
using System;
using System.Threading.Tasks;
using SSY.Products.Holidays.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp;
using SSY.Products.Options.Dtos;
using SSY.Products.Options;
using System.Linq;

namespace SSY.Products.Holidays
{
    public class HolidayAppService : CrudAppService<Holiday, HolidayDto, long, PagedAndSortedResultRequestDto, CreateHolidayDto, UpdateHolidayDto>, IHolidayAppService
    {
        public HolidayAppService(IRepository<Holiday, long> repository) : base(repository)
        {
        }
        public override async Task<HolidayDto> CreateAsync(CreateHolidayDto input)
        {
            try
            {
                
               var res= await  base.CreateAsync(input);
                return res;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }
        protected override async Task<IQueryable<Holiday>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var result=await base.CreateFilteredQueryAsync(input);
            return result;
        }
    }
}
