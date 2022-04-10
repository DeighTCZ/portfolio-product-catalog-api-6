using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog_data_access.Dao.EF;
using product_catalog_data_access.Dao.Mock;
using product_catalog_data_access.EfModels;
using product_catalog_data_access.EfModels.Automapper;
using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Automapper;

namespace product_catalog_api;

/// <summary>
/// Konfigurační objekt
/// </summary>
public static class Startup
{
    /// <summary>
    /// Nastaví Entity Framework jako metodu pro přístup k datům
    /// </summary>
    /// <param name="builder"></param>
    public static void AddEfImplementation(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProductCatalogDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EfProductCatalogContext")));

        builder.Services.AddTransient<IProductDao, EfProductDao>();
        builder.Services.AddTransient<IUserDao, EfUserDao>();
    }

    /// <summary>
    /// NAstaví Mock jako metodu pro přístup k datům
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMockImplementation(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IProductDao, MockProductDao>();
        builder.Services.AddSingleton<IUserDao, MockUserDao>();
    }

    /// <summary>
    /// Provede nastavení automapperu
    /// </summary>
    /// <param name="builder"></param>
    public static void CreateAutomapperConfig(this WebApplicationBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ProductMapperProfile());
            mc.AddProfile(new UserMapperProfile());
            mc.AddProfile(new DtoMapperProfile());
        });

        mapperConfig.AssertConfigurationIsValid();

        var mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);
    }
}
