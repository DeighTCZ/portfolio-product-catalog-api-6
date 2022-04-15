using AutoMapper;
using product_catalog_data_model.Dto.Product;

namespace product_catalog_data_model.Automapper;

/// <summary>
/// Mapovací profil pro DTO objekty
/// </summary>
public class DtoMapperProfile : Profile
{
    /// <summary>
    /// ctor
    /// </summary>
    public DtoMapperProfile()
    {
        CreateMap<Model.Product, Product>();
        CreateMap<Product, Model.Product>();

        CreateMap<CreateProductDto, Model.Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Model.Product, CreateProductDto>()
            .ForSourceMember(source => source.Id, opt => opt.DoNotValidate());
    }
}
