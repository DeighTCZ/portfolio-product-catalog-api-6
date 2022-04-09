using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using product_catalog_api.Controllers;
using product_catalog_api.Services;
using product_catalog_api.tests.MockData;
using Xunit;

namespace product_catalog_api.tests.Controllers;

public class ProductControllerTests
{
    [Fact]
    public async Task GetAll_ShouldReturn200Status()
    {
        // Arrange
        var productService = new Mock<IProductService>();
        var mapper = new Mock<IMapper>();
        var mockDataProvider = new ProductsMockData();
        productService.Setup(_ => _.GetAllProducts()).Returns(mockDataProvider.GetAll());
        var sut = new ProductController(mapper.Object, productService.Object);

        // Act
        var result = (OkObjectResult)sut.GetProducts();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}
