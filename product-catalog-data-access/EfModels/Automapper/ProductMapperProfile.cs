using AutoMapper;

namespace product_catalog_data_access.EfModels.Automapper;

/// <summary>
/// Mapovací profil mezi entitou a objektem produktu
/// </summary>
public class ProductMapperProfile : Profile
{
    /// <summary>
    /// ctor
    /// </summary>
    public ProductMapperProfile()
    {
        CreateMap<product_catalog_data_model.Model.Product, Product>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name));
        CreateMap<Product, product_catalog_data_model.Model.Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));
    }
}
