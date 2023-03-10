using System.Linq;
using AutoMapper;
using SSY.Products.BillOfMaterials.Dtos;
using SSY.Products.Collections.AssignedTos;
using SSY.Products.Collections.AssignedTos.Dtos;
using SSY.Products.Dtos;
using SSY.Products.RejectionNotes;
using SSY.Products.RejectionNotes.Dtos;

namespace SSY.Products.BillOfMaterials;

public class AssignedToApplicationAutoMapperProfile : Profile
{
    public AssignedToApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<AssignedTo, AssignedToDto>()
            .ForMember(x => x.Collection, opt => opt.Ignore());
        CreateMap<CreateAssignedToDto, AssignedTo>();
        CreateMap<UpdateAssignedToDto, AssignedTo>()
            .ForMember(x => x.Collection, opt => opt.Ignore());
    }
}