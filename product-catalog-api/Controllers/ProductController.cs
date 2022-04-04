using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Dto;

namespace product_catalog_api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductDao _dao;

    private readonly IMapper _mapper;

    public ProductController(IMapper mapper, IProductDao dao)
    {
        _mapper = mapper;
        _dao = dao;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult GetProducts()
    {
        var items = _dao.GetAll();

        var result = _mapper.Map<IEnumerable<product_catalog_data_model.Model.Product>, IEnumerable<Product>>(items);

        return Ok(result);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult GetProduct(long id)
    {
        var item = _dao.GetById(id);

        var result = _mapper.Map<product_catalog_data_model.Model.Product>(item);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult Create([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        _dao.Create(item);

        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult Update([FromBody] Product product)
    {
        var item = _mapper.Map<product_catalog_data_model.Model.Product>(product);

        _dao.Update(item);

        return Ok();
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult Delete(long id)
    {
        _dao.Delete(id);

        return Ok();
    }
}
