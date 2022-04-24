using System.Linq;
using System.Threading;
using FluentAssertions;
using product_catalog_data_access.Dao.Mock;
using product_catalog_data_model.Exceptions;
using product_catalog_data_model.Model;
using Xunit;

namespace product_catalog_data_access.tests.Dao.Mock;

public class MockProductDaoTests
{
    [Fact]
    public async void GetAll_ResultCount()
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();
        var items = await mockProductDao.GetAll(ct);

        items.Should().HaveCount(2);
    }

    [Fact]
    public async void GetAllPaged_ResultCount()
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var items = await mockProductDao.GetAllPaged(1, 10, ct);

        items.Should().HaveCount(2);
    }

    [Fact]
    public async void GetAllPaged_PageNotValidException()
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        const int Page = 2;

        var ex = await Assert.ThrowsAsync<PageNotValidException>(() => mockProductDao.GetAllPaged(Page, 10, ct));

        ex.Should().BeOfType<PageNotValidException>();

        Assert.Equal($"Zadaná stránka {Page} není validní.", ex.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void GetById_Succes(long id)
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var item = await mockProductDao.GetById(id, ct);

        item.Id.Should().Be(id);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(22)]
    public async void GetById_NotFoundException(long id)
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var ex = await Assert.ThrowsAsync<ItemNotFoundException>(() => mockProductDao.GetById(id, ct));

        ex.Should().BeOfType<ItemNotFoundException>();

        Assert.Equal($"Produkt se zadaným id {id} nebyl nalezen.", ex.Message);
    }

    [Fact]
    public async void Create_Success()
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var items = await mockProductDao.GetAll(ct);

        var itemsCount = items.Count();

        var product = new Product
        {
            Name = "TestProduct",
            Description = "TestProduct description",
            Price = 123456.7m,
            ImageUri = "https://testuri.cz"
        };

        await mockProductDao.Create(product, ct);

        var items2 = await mockProductDao.GetAll(ct);

        items2.Count().Should().Be(itemsCount + 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void Delete_Succes(long id)
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var items = await mockProductDao.GetAll(ct);

        var itemsCount = items.Count();

        await mockProductDao.Delete(id, ct);

        var items2 = await mockProductDao.GetAll(ct);

        items2.Count().Should().Be(itemsCount - 1);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(22)]
    public async void Delete_ItemNotFoundException(long id)
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var ex = await Assert.ThrowsAsync<ItemNotFoundException>(() => mockProductDao.Delete(id, ct));

        ex.Should().BeOfType<ItemNotFoundException>();

        Assert.Equal($"Produkt se zadaným id {id} nebyl nalezen.", ex.Message);

        var items = await mockProductDao.GetAll(ct);

        items.Count().Should().Be(2);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void Update_Success(long id)
    {
        var mockProductDao = new MockProductDao();
        var ct = new CancellationToken();

        var product = await mockProductDao.GetById(id, ct);

        var firstDescription = product.Description;

        product.Description = "TEST DESCRIPTION";

        await mockProductDao.Update(id, product, ct);

        var product2 = await mockProductDao.GetById(id, ct);

        product.Id.Should().Be(product2.Id);

        product2.Description.Should().NotBe(firstDescription).And.Be("TEST DESCRIPTION");
    }
}
