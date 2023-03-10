using AutoMapper;
using SSY.Products.ApprovalStatuses.Dtos;

namespace SSY.Products.ApprovalStatuses;

public class ApprovalStatusApplicationAutoMapperProfile : Profile
{
    public ApprovalStatusApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ApprovalStatus, ApprovalStatusDto>();
        CreateMap<CreateApprovalStatusDto, ApprovalStatus>();
        CreateMap<UpdateApprovalStatusDto, ApprovalStatus>();
    }
}