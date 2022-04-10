using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using product_catalog_api.Filters;
using product_catalog_api.Services;
using product_catalog_data_model.Dto;

namespace product_catalog_api.Controllers;

/// <summary>
/// Jednoduchá verze kontrolleru pro práci s produkty
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/products")]
[ApiVersion("1.0", Deprecated = true)]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    private readonly IMapper _mapper;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="productService"></param>
    public ProductController(IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _productService = productService;
    }

    /// <summary>
    /// Vrátí seznam produktů
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProducts()
    {
        var items = await _productService.GetAllProducts();

        var result = _mapper.Map<IEnumerable<product_catalog_data_model.Model.Product>, IEnumerable<Product>>(items);

        return Ok(result);
    }

    /// <summary>
    /// Vrací produkt podle id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProduct(long id)
    {
        var item = await _productService.GetProductById(id);

        var result = _mapper.Map<product_catalog_data_model.Model.Product>(item);

        return Ok(result);
    }

    /// <summary>
    /// Vytváří produkt
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        await _productService.CreateProduct(item);

        return Ok();
    }

    /// <summary>
    /// Upravuje produkt
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        await _productService.UpdateProduct(item);

        return Ok();
    }

    /// <summary>
    /// Maže produkt
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Delete(long id)
    {
        await _productService.DeleteProduct(id);

        return Ok();
    }
}
