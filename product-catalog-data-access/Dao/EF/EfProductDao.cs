using product_catalog_data_access.EfModels;
using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Exceptions;
using Product = product_catalog_data_model.Model.Product;

namespace product_catalog_data_access.Dao.EF;

/// <summary>
/// Implementace přístupu k datům přes EF
/// </summary>
public class EfProductDao : IProductDao
{
    //TODO automapper

    private readonly ProductCatalogDbContext _context;

    public EfProductDao(ProductCatalogDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.Select(x => new Product
        {
            Id = x.Id,
            Name = x.ProductName,
            Description = x.Description,
            ImageUri = x.ImageUri,
            Price = x.Price
        });
    }

    public Product GetById(long id)
    {
        var product = GetByIdInternal(id);

        return new Product
        {
            Id = product.Id,
            Name = product.ProductName,
            Description = product.Description,
            Price = product.Price,
            ImageUri = product.ImageUri
        };
    }

    public void Create(Product item)
    {
        var product = new EfModels.Product
        {
            ProductName = item.Name,
            Description = item.Description,
            ImageUri = item.ImageUri,
            Price = item.Price
        };

        _context.Products.Add(product);
    }

    public void Update(Product item)
    {
        var product = GetByIdInternal(item.Id);

        product.ProductName = item.Name;
        product.Description = item.Description;
        product.ImageUri = item.ImageUri;
        product.Price = item.Price;

        _context.Products.Update(product);
    }

    public void Delete(long id)
    {
        var product = GetByIdInternal(id);

        _context.Remove(product);
    }

    private EfModels.Product GetByIdInternal(long id)
    {
        var item = _context.Products.Find(id);

        if (item == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        return item;
    }
}
