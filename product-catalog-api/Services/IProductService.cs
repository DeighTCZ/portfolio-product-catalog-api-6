using product_catalog_data_model.Model;

namespace product_catalog_api.Services;

/// <summary>
/// SLužba pro práci s produkty
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Vrátí veškeré produkty
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Product>> GetAllProducts();

    /// <summary>
    /// Vrátí produkty stránkovaně
    /// </summary>
    /// <param name="page"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public Task<IEnumerable<Product>> GetProductsPaged(int page, int count);

    /// <summary>
    /// Vrátí produkt podle id
    /// </summary>
    /// <returns></returns>
    public Task<Product> GetProductById(long id);

    /// <summary>
    /// Vytvoří produkt
    /// </summary>
    /// <param name="product"></param>
    public Task CreateProduct(Product product);

    /// <summary>
    /// Upraví produkt
    /// </summary>
    /// <param name="product"></param>
    public Task UpdateProduct(Product product);

    /// <summary>
    /// Smaže produkt
    /// </summary>
    /// <param name="id"></param>
    public Task DeleteProduct(long id);
}
