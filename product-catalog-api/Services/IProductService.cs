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
    public IEnumerable<Product> GetAllProducts();

    /// <summary>
    /// Vrátí produkt podle id
    /// </summary>
    /// <returns></returns>
    public Product GetProductById(long id);

    /// <summary>
    /// Vytvoří produkt
    /// </summary>
    /// <param name="product"></param>
    public void CreateProduct(Product product);

    /// <summary>
    /// Upraví produkt
    /// </summary>
    /// <param name="product"></param>
    public void UpdateProduct(Product product);

    /// <summary>
    /// Smaže produkt
    /// </summary>
    /// <param name="id"></param>
    public void DeleteProduct(long id);
}
