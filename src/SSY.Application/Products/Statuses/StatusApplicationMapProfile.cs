using AutoMapper;
using SSY.Products.Statuses.Dtos;

namespace SSY.Products.Statuses;

public class StatusApplicationMapProfile : Profile
{
    public StatusApplicationMapProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Status, StatusDto>();
        CreateMap<CreateStatusDto, Status>()
            .ForMember(x => x.DesignStatus, opt => opt.Ignore());
        CreateMap<UpdateStatusDto, Status>()
            .ForMember(x => x.DesignStatus, opt => opt.Ignore());
    }
}