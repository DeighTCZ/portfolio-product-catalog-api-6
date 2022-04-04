using AutoMapper;
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
    private readonly ProductCatalogDbContext _context;

    private readonly IMapper _mapper;

    public EfProductDao(IMapper mapper, ProductCatalogDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    
    public IEnumerable<Product> GetAll()
    {
        return _mapper.Map<IEnumerable<EfModels.Product>, IEnumerable<Product>>(_context.Products);
    }

    public Product GetById(long id)
    {
        var product = GetByIdInternal(id);

        return _mapper.Map<Product>(product);
    }

    public void Create(Product item)
    {
        var product = _mapper.Map<EfModels.Product>(item);

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
