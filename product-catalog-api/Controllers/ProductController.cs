using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using product_catalog_api.Services;
using product_catalog_data_model.Dto;

namespace product_catalog_api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    private readonly IMapper _mapper;

    public ProductController(IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _productService = productService;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProducts()
    {
        var items = await _productService.GetAllProducts();

        var result = _mapper.Map<IEnumerable<product_catalog_data_model.Model.Product>, IEnumerable<Product>>(items);

        return Ok(result);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProduct(long id)
    {
        var item = await _productService.GetProductById(id);

        var result = _mapper.Map<product_catalog_data_model.Model.Product>(item);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        await _productService.CreateProduct(item);

        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        await _productService.UpdateProduct(item);

        return Ok();
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Delete(long id)
    {
        await _productService.DeleteProduct(id);

        return Ok();
    }
}
