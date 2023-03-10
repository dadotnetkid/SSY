using AutoMapper;
using SSY.Products.Accountings.Dtos;

namespace SSY.Products.Accountings;

public class AccountingApplicationAutoMapperProfile : Profile
{
    public AccountingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Accounting, AccountingDto>();
        CreateMap<CreateAccountingDto, Accounting>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            ;
        CreateMap<UpdateAccountingDto, Accounting>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            ;
    }
}