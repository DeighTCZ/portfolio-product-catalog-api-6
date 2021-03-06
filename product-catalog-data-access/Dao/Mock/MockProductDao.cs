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

    /// <summary>
    /// ctor
    /// </summary>
    public MockProductDao()
    {
        _products = new ProductMockDataProvider().GetAll().ToList();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetAll(CancellationToken ct)
    {
        return await Task.FromResult(_products);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetAllPaged(int page, int count, CancellationToken ct)
    {
        var productsCount = _products.Count;
        var skip = Utility.SkipForPage(page, count);
        if (skip > productsCount)
        {
            throw new PageNotValidException($"Zadaná stránka {page} není validní.");
        }

        return await Task.FromResult(_products.Skip(skip).Take(count));
    }

    /// <inheritdoc />
    public async Task<Product> GetById(long id, CancellationToken ct)
    {
        var products = await GetAll(ct);

        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        return product;
    }

    /// <inheritdoc />
    public async Task<long> Create(Product item, CancellationToken ct)
    {
        //hack tady nemám identity
        var lastId = _products.Last().Id;
        item.Id = lastId + 1;

        _products.Add(item);

        return await Task.FromResult(0);
    }

    /// <inheritdoc />
    public async Task Update(long id, Product item, CancellationToken ct)
    {
        var product = await GetById(id, ct);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {item.Id} nebyl nalezen.");
        }

        product.Description = item.Description;
        product.Name = item.Name;
        product.Price = item.Price;
        product.ImageUri = item.ImageUri;
    }

    /// <inheritdoc />
    public async Task UpdateDescription(long id, string description, CancellationToken ct)
    {
        var product = await GetById(id, ct);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        product.Description = description;
    }

    /// <inheritdoc />
    public async Task Delete(long id, CancellationToken ct)
    {
        var product = await GetById(id, ct);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        _products.Remove(product);
    }
}
