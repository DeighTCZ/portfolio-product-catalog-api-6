using AutoMapper;
using product_catalog_data_model.Dto;

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
    }
}
