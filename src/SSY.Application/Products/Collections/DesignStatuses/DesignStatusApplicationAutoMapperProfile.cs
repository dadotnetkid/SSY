using AutoMapper;
using SSY.Products.Collections.DesignStatuses.Dtos;

namespace SSY.Products.Collections.DesignStatuses;

public class DesignStatusApplicationAutoMapperProfile : Profile
{
    public DesignStatusApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<DesignStatus, DesignStatusDto>();
        CreateMap<CreateDesignStatusDto, DesignStatus>();
        CreateMap<UpdateDesignStatusDto, DesignStatus>();
    }
}