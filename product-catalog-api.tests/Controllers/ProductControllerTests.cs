using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using product_catalog_api.Controllers;
using product_catalog_api.Services;
using product_catalog_data_access.Dao.Mock;
using product_catalog_data_model.Exceptions;
using Xunit;

namespace product_catalog_api.tests.Controllers;

public class ProductControllerTests
{
    [Fact]
    public async Task GetAll_ShouldReturn200Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);
        var ct = new CancellationToken();

        // Act
        var result = (OkObjectResult)await sut.GetProducts(ct);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturn200Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);
        var ct = new CancellationToken();

        // Act
        var result = (OkObjectResult)await sut.GetProduct(1, ct);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturn404Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);
        var ct = new CancellationToken();

        // Act
        var ex = await Assert.ThrowsAsync<ItemNotFoundException>(() => sut.GetProduct(100, ct));

        //Assert
        ex.Should().BeOfType<ItemNotFoundException>();
    }
}
