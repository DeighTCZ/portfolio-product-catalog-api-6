using Newtonsoft.Json;

namespace product_catalog_api.Filters;

/// <summary>
/// Model pro errorové stavy
/// </summary>
public class ErrorResult
{
    /// <summary>
    /// Typ erroru
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Status Code
    /// </summary>
    [JsonProperty("statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// Zpráva
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }
}
