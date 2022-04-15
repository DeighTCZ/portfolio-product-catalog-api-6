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
    public string Name { get; init; }

    /// <summary>
    /// Popis produktu
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; init; }

    /// <summary>
    /// Uri obrázku produktu
    /// </summary>
    [JsonProperty("imageUrl")]
    public string ImageUri { get; init; }

    /// <summary>
    /// Cena produktu
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; init; }
}
