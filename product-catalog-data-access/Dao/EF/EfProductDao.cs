using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="context"></param>
    public EfProductDao(IMapper mapper, ProductCatalogDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetAll()
    {
        var data = await _context.Products.ToListAsync();
        return _mapper.Map<IEnumerable<EfModels.Product>, IEnumerable<Product>>(data);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetAllPaged(int page, int count)
    {
        var productsCount = await _context.Products.CountAsync();
        var skip = Utility.SkipForPage(page, count);
        if (skip > productsCount)
        {
            throw new PageNotValidException($"Zadaná stránka {page} není validní.");
        }

        var data = await _context.Products.Skip(skip).Take(count).ToListAsync();
        return _mapper.Map<IEnumerable<EfModels.Product>, IEnumerable<Product>>(data);
    }

    /// <inheritdoc />
    public async Task<Product> GetById(long id)
    {
        var product = await GetByIdInternal(id);

        return _mapper.Map<Product>(product);
    }

    /// <inheritdoc />
    public async Task<long> Create(Product item)
    {
        var product = _mapper.Map<EfModels.Product>(item);

        _context.Add(product);

        await _context.SaveChangesAsync();

        return product.Id;
    }

    /// <inheritdoc />
    public async Task Update(long id, Product item)
    {
        var product = await GetByIdInternal(id);

        product.ProductName = item.Name;
        product.Description = item.Description;
        product.ImageUri = item.ImageUri;
        product.Price = item.Price;

        _context.Update(product);

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateDescription(long id, string description)
    {
        var product = await GetByIdInternal(id);

        product.Description = description;

        _context.Update(product);

        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task Delete(long id)
    {
        var product = await GetByIdInternal(id);

        _context.Remove(product);

        await _context.SaveChangesAsync();
    }

    private async Task<EfModels.Product> GetByIdInternal(long id)
    {
        var item = await _context.Products.FindAsync(id);

        if (item == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        return item;
    }
}
