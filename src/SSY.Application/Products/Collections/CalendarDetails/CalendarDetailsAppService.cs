using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Products.Collections.CalendarDetails.Dto;
using SSY.Products.Collections.Calendars;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.CalendarDetails
{
    public class CalendarDetailsAppService : CrudAppService<CalendarDetail, CalendarDetailDto, Guid, PagedAndSortedResultRequestDto, CreateCalendarDetailDto, UpdateCalendarDetailDto>, ICalendarDetailsAppService
    {
        private readonly IRepository<Calendar, Guid> _calendarRepository;

        public CalendarDetailsAppService(IRepository<CalendarDetail, Guid> repository, IRepository<Calendar, Guid> calendarRepository) : base(repository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task UpdateCalendarStatus(Guid collectionId, int productStatusId)
        {
            var res = await _calendarRepository.FirstOrDefaultAsync(c => c.CollectionId == collectionId);
            if (res == null) return;
            await CreateAsync(new CreateCalendarDetailDto()
            {
                CalendarId = res.Id,
                ProductStatusId = productStatusId,
                IsActive=true,
            });

        }
        public override async Task<CalendarDetailDto> CreateAsync(CreateCalendarDetailDto input)
        {
            try
            {
                return await base.CreateAsync(input);
            }
            catch (Exception ex)
            {

                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = "{ex.Message}{innerException}";
                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }


    }
}
