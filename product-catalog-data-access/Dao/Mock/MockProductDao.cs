﻿using product_catalog_data_access.Interfaces;
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
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await Task.FromResult(_products);
    }

    /// <inheritdoc />
    public async Task<Product> GetById(long id)
    {
        var products = await GetAll();

        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        return product;
    }

    /// <inheritdoc />
    public async Task Create(Product item)
    {
        _products.Add(item);

        await Task.FromResult(0);
    }

    /// <inheritdoc />
    public async Task Update(Product item)
    {
        var product = await GetById(item.Id);

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
    public async Task Delete(long id)
    {
        var product = await GetById(id);

        if (product == null)
        {
            throw new ItemNotFoundException($"Produkt se zadaným id {id} nebyl nalezen.");
        }

        _products.Remove(product);
    }
}
