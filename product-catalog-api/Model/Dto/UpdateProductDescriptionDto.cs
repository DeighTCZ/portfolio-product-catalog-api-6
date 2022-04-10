using Newtonsoft.Json;

namespace product_catalog_api.Model.Dto;

/// <summary>
/// DTO pro úpravu popisu produktu
/// </summary>
public class UpdateProductDescriptionDto
{
    /// <summary>
    /// Id
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; }

    /// <summary>
    /// Popis produktu
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; init; }
}
