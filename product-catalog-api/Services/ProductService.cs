using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Model;

namespace product_catalog_api.Services;

/// <summary>
/// Servica pro práci s produkty
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductDao _productDao;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dao"></param>
    public ProductService(IProductDao dao)
    {
        _productDao = dao;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var products = await _productDao.GetAll();

        // Bussiness logic here

        return products;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetProductsPaged(int page, int count)
    {
        var products = await _productDao.GetAllPaged(page, count);

        // Bussiness logic here

        return products;
    }

    /// <inheritdoc />
    public async Task<Product> GetProductById(long id)
    {
        var product = await _productDao.GetById(id);

        // Bussiness logic here

        return product;
    }

    /// <inheritdoc />
    public async Task<long> CreateProduct(Product product)
    {
        // Bussiness logic here

        return await _productDao.Create(product);
    }

    /// <inheritdoc />
    public async Task UpdateProduct(long id, Product product)
    {
        // Bussiness logic here

        await _productDao.Update(id, product);
    }

    /// <inheritdoc />
    public async Task UpdateProductDescription(long id, string description)
    {
        // Bussiness logic here

        await _productDao.UpdateDescription(id, description);
    }

    /// <inheritdoc />
    public async Task DeleteProduct(long id)
    {
        // Bussiness logic here

        await _productDao.Delete(id);
    }
}
