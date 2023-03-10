using AutoMapper;
using SSY.Products.Collections.Statuses.Dtos;

namespace SSY.Products.Collections.Statuses;

public class StatusApplicationAutoMapperProfile : Profile
{
    public StatusApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Status, StatusDto>();
        CreateMap<CreateStatusDto, Status>();
        CreateMap<UpdateStatusDto, Status>();
    }
}