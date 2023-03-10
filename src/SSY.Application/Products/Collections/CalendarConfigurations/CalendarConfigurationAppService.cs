using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Products.Collections.CalendarConfigurations.Dtos;
using SSY.Products.Collections.CalendarConfigurations;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.CalendarConfigurations
{
    public class CalendarConfigurationAppService : CrudAppService<CalendarConfiguration, CalendarConfigurationDto, int, PagedAndSortedResultRequestDto, CreateCalendarConfigurationDto, UpdateCalendarConfigurationDto>, ICalendarConfigurationsAppService
    {
        public CalendarConfigurationAppService(IRepository<CalendarConfiguration, int> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<CalendarConfiguration>> CreateFilteredQueryAsync(
            PagedAndSortedResultRequestDto input)
        {
            try
            {
                return await base.CreateFilteredQueryAsync(input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public override async Task<CalendarConfigurationDto> CreateAsync(CreateCalendarConfigurationDto input)
        {
            try
            {
                return await base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                var innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }
        public override async Task<CalendarConfigurationDto> UpdateAsync(int id, UpdateCalendarConfigurationDto input)
        {

            try
            {
                return await base.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }
    }
}
