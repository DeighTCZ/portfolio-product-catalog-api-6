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
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<IEnumerable<Product>> GetAllProducts(CancellationToken ct);

    /// <summary>
    /// Vrátí produkty stránkovaně
    /// </summary>
    /// <param name="page"></param>
    /// <param name="count"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<IEnumerable<Product>> GetProductsPaged(int page, int count, CancellationToken ct);

    /// <summary>
    /// Vrátí produkt podle id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Product> GetProductById(long id, CancellationToken ct);

    /// <summary>
    /// Vytvoří produkt
    /// </summary>
    /// <param name="product"></param>
    /// <param name="ct"></param>
    public Task<long> CreateProduct(Product product, CancellationToken ct);

    /// <summary>
    /// Upraví produkt
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <param name="ct"></param>
    public Task UpdateProduct(long id, Product product, CancellationToken ct);

    /// <summary>
    /// Upraví popis produktu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task UpdateProductDescription(long id, string description, CancellationToken ct);

    /// <summary>
    /// Smaže produkt
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    public Task DeleteProduct(long id, CancellationToken ct);
}
