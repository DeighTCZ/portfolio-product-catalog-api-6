using product_catalog_data_model.Model;

namespace product_catalog_data_access.Interfaces;

/// <summary>
/// Interface pro dao produktů
/// </summary>
public interface IProductDao : IDao<Product>
{
    /// <summary>
    /// Upraví popis produktu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public Task UpdateDescription(long id, string description);
}
