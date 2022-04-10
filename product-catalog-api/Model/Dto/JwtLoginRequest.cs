using Newtonsoft.Json;

namespace product_catalog_api.Model.Dto;

/// <summary>
/// Model pro přihlášení
/// </summary>
public class JwtLoginRequest
{
    /// <summary>
    /// Jméno
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; set; }

    /// <summary>
    /// Heslo
    /// </summary>
    [JsonProperty("password")]
    public string Password { get; set; }
}
