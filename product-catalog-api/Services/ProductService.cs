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
    public IEnumerable<Product> GetAllProducts()
    {
        var products = _productDao.GetAll();

        // Bussiness logic here

        return products;
    }

    /// <inheritdoc />
    public Product GetProductById(long id)
    {
        var product = _productDao.GetById(id);

        // Bussiness logic here

        return product;
    }

    /// <inheritdoc />
    public void CreateProduct(Product product)
    {
        // Bussiness logic here

        _productDao.Create(product);
    }

    /// <inheritdoc />
    public void UpdateProduct(Product product)
    {
        // Bussiness logic here

        _productDao.Update(product);
    }

    /// <inheritdoc />
    public void DeleteProduct(long id)
    {
        // Bussiness logic here

        _productDao.Delete(id);
    }
}
