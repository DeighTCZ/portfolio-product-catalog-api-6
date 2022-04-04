using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Exceptions;
using product_catalog_data_model.Model;

namespace product_catalog_data_access.Dao.Mock;

/// <summary>
/// Implementace mockovaného přístupu k datům
/// </summary>
public class MockProductDao : IProductDao
{
    private readonly List<Product> _products = new ()
    {
        new Product
        {
            Id = 1,
            Name = "Product A",
            Description = "Popis produktu A",
            Price = 1458.99m,
            ImageUri = "https://fakeuri.cz/produktA"
        },
        new Product
        {
            Id = 2,
            Name = "Product B",
            Description = "Popis produktu B",
            Price = 145458.99m,
            ImageUri = "https://fakeuri.cz/produktB"
        }
    };

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product GetById(long id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id);
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
