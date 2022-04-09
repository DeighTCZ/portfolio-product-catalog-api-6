using product_catalog_data_model.Model;

namespace product_catalog_mock_data;

public class ProductMockDataProvider
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

    public  IEnumerable<Product> GetAll()
    {
        return _products;
    }
}
