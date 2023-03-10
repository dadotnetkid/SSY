using AutoMapper;
using SSY.Products.BillOfMaterials.Dtos;

namespace SSY.Products.BillOfMaterials;

public class BillOfMaterialApplicationAutoMapperProfile : Profile
{
    public BillOfMaterialApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BillOfMaterial, BillOfMaterialDto>();
        CreateMap<CreateBillOfMaterialDto, BillOfMaterial>();
        CreateMap<UpdateBillOfMaterialDto, BillOfMaterial>();
    }
}