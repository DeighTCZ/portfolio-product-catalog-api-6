using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Exceptions;
using product_catalog_data_model.Model;
using product_catalog_mock_data;

namespace product_catalog_data_access.Dao.Mock;

/// <summary>
/// Implementace mockovaného přístupu k datům
/// </summary>
public class MockProductDao : IProductDao
{
    private readonly List<Product> _products;

    public MockProductDao()
    {
        _products = new ProductMockDataProvider().GetAll().ToList();
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product GetById(long id)
    {
        var product = GetAll().FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        return product;
    }

    public void Create(Product item)
    {
        _products.Add(item);
    }

    public void Update(Product item)
    {
        var product = GetById(item.Id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {item.Id} nebyl nalezen.");
        }

        product.Description = item.Description;
        product.Name = item.Name;
        product.Price = item.Price;
        product.ImageUri = item.ImageUri;
    }

    public void Delete(long id)
    {
        var product = GetById(id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        _products.Remove(product);
    }
}
