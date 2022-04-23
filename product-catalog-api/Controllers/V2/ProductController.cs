using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_catalog_api.Filters;
using product_catalog_api.Model.Dto;
using product_catalog_api.Model.Dto.Product;
using product_catalog_api.Services;
using product_catalog_data_model.Dto.Product;

namespace product_catalog_api.Controllers.V2;

/// <summary>
/// Novější verze kontrolleru pro práci s produkty
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
[Authorize]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    /// Vrací seznam produktů
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProducts([FromQuery] PaginationDto pagination)
    {
        var items = await _productService.GetProductsPaged(pagination.Page, pagination.Count);

        var result = _mapper.Map<IEnumerable<product_catalog_data_model.Model.Product>, IEnumerable<Product>>(items);

        return Ok(result);
    }

    /// <summary>
    /// Vrací produkt podle id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProduct(long id)
    {
        var item = await _productService.GetProductById(id);

        var result = _mapper.Map<product_catalog_data_model.Model.Product>(item);

        return Ok(result);
    }

    /// <summary>
    /// Vytvoří produkt
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create([FromBody] CreateProductDto product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        var createdId = await _productService.CreateProduct(item);

        return Created($"/{createdId}", product);
    }

    /// <summary>
    /// Upravuje produkt
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateProductDto product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        await _productService.UpdateProduct(id, item);

        return NoContent();
    }

    /// <summary>
    /// Upraví popis produktu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateDescription(long id, [FromBody] UpdateProductDescriptionDto dto)
    {
        await _productService.UpdateProductDescription(id, dto.Description);

        return NoContent();
    }

    /// <summary>
    /// Smaže produkt
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Delete(long id)
    {
        await _productService.DeleteProduct(id);

        return NoContent();
    }
}
