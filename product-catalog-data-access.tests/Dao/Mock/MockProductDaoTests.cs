using System.Linq;
using FluentAssertions;
using product_catalog_data_access.Dao.Mock;
using product_catalog_data_model.Exceptions;
using Xunit;

namespace product_catalog_data_access.tests.Dao.Mock;

public class MockProductDaoTests
{
    [Fact]
    public void GetAll_ResultCount()
    {
        var mockProductDao = new MockProductDao();

        var items = mockProductDao.GetAll().ToList();

        items.Should().HaveCount(2);
    }

    [Fact]
    public void GetById_Succes()
    {
        var mockProductDao = new MockProductDao();

        var item = mockProductDao.GetById(1);

        item.Id.Should().Be(1);
    }

    [Fact]
    public void GetById_Exception()
    {
        var mockProductDao = new MockProductDao();

        const int Id = 100000;

        var ex = Assert.Throws<ItemNotFoundException>(() => mockProductDao.GetById(Id));

        Assert.Equal($"Produkt se zadaným id {Id} nebyl nalezen.", ex.Message);
    }
}
