using AutoMapper;

namespace product_catalog_data_access.EfModels.Automapper;

/// <summary>
/// Mapovací profil mezi entitou a objektem uživatele
/// </summary>
public class UserMapperProfile : Profile
{
    /// <summary>
    /// ctor
    /// </summary>
    public UserMapperProfile()
    {
        CreateMap<product_catalog_data_model.Model.Security.User, User>();
        CreateMap<User, product_catalog_data_model.Model.Security.User>();
    }
}
