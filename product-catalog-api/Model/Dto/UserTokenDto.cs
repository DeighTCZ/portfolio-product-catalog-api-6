using Newtonsoft.Json;

namespace product_catalog_api.Model.Dto;

/// <summary>
/// Model pro přenos tokenu
/// </summary>
public class UserTokenDto
{
    /// <summary>
    /// Login
    /// </summary>
    [JsonProperty("login")]
    public string Login { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    [JsonProperty("token")]
    public string Token { get; set; }
}
