using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using product_catalog_api.Controllers.V2;
using product_catalog_api.Model.Dto;
using product_catalog_api.Services;
using product_catalog_data_access.Dao.Mock;
using product_catalog_data_model.Exceptions;
using Xunit;

namespace product_catalog_api.tests.Controllers.V2;

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

        // Act
        var result = (OkObjectResult)await sut.GetProducts(new PaginationDto());

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetPaged_ShouldReturn200Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);

        // Act
        var result = (OkObjectResult)await sut.GetProducts(new PaginationDto(1, 10));

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetPaged_ShouldReturn400Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);

        // Act
        var ex = await Assert.ThrowsAsync<PageNotValidException>(() => sut.GetProducts(new PaginationDto(100, 10)));

        //Assert
        ex.Should().BeOfType<PageNotValidException>();
    }

    [Fact]
    public async Task GetById_ShouldReturn200Status()
    {
        // Arrange
        var dao = new MockProductDao();
        var productService = new ProductService(dao);
        var mapper = new Mock<IMapper>();
        var sut = new ProductController(mapper.Object, productService);

        // Act
        var result = (OkObjectResult)await sut.GetProduct(1);

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

        // Act
        var ex = await Assert.ThrowsAsync<ItemNotFoundException>(() => sut.GetProduct(100));

        //Assert
        ex.Should().BeOfType<ItemNotFoundException>();
    }
}
