using AutoMapper;

namespace product_catalog_data_access.EfModels.Automapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<product_catalog_data_model.Model.Security.User, User>();
        CreateMap<User, product_catalog_data_model.Model.Security.User>();
    }
}
