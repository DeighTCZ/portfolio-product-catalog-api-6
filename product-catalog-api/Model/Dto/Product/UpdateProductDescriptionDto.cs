using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace product_catalog_api.Model.Dto.Product;

/// <summary>
/// DTO pro úpravu popisu produktu
/// </summary>
public class UpdateProductDescriptionDto
{
    /// <summary>
    /// Popis produktu
    /// </summary>
    [JsonProperty("description")]
    [MaxLength(1000, ErrorMessage = "Popis může mít maximálně 1000 znaků.")] // Ne Hardcode text, ale kód pro lokalizaci
    public string Description { get; init; }
}
