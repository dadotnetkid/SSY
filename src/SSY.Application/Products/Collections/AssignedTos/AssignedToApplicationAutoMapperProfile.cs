using AutoMapper;
using SSY.Products.Collections.AssignedTos.Dtos;

namespace SSY.Products.Collections.AssignedTos;

public class AssignedToApplicationAutoMapperProfile : Profile
{
    public AssignedToApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<AssignedTo, AssignedToDto>();
        CreateMap<CreateAssignedToDto, AssignedTo>();
        CreateMap<UpdateAssignedToDto, AssignedTo>();
    }
}