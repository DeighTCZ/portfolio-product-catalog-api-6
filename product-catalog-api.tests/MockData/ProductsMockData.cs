using System.Collections.Generic;
using product_catalog_data_model.Model;
using product_catalog_mock_data;

namespace product_catalog_api.tests.MockData;

public class ProductsMockData
{
    private readonly ProductMockDataProvider _productsProvider;

    public ProductsMockData()
    {
        _productsProvider = new ProductMockDataProvider();
    }

    public IEnumerable<Product> GetAll()
    {
        return _productsProvider.GetAll();
    }
}
