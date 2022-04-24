using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace product_catalog_data_model.Dto.Product;

/// <summary>
/// Dto pro vytvoření produktu
/// </summary>
public class CreateProductDto
{
    /// <summary>
    /// Název produktu
    /// </summary>
    [JsonProperty("name")]
    [Required(ErrorMessage = "Název produktu je povinný")]
    [MaxLength(64, ErrorMessage = "Název produktu může mít maximálně {0} znaků.")]
    public string Name { get; init; }

    /// <summary>
    /// Popis produktu
    /// </summary>
    [JsonProperty("description")]
    [MaxLength(1000, ErrorMessage = "Popis produktu může mít maximálně {0} znaků.")]
    public string Description { get; init; }

    /// <summary>
    /// Uri obrázku produktu
    /// </summary>
    [JsonProperty("imageUrl")]
    [Required(ErrorMessage = "Odkaz na obrázek je povinný.")]
    [MaxLength(50, ErrorMessage = "Odkaz na obrázek produktu může mít maximálně {0} znaků.")]
    public string ImageUri { get; init; }

    /// <summary>
    /// Cena produktu
    /// </summary>
    [JsonProperty("price")]
    [Required(ErrorMessage = "Cena produktu je povinné.")]
    [Range(0, double.MaxValue, ErrorMessage = "Cena produktu musí být kladné číslo.")]
    public decimal Price { get; init; }
}
