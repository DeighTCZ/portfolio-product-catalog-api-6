using System.ComponentModel.DataAnnotations;
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
    [Required(ErrorMessage = "Uživatelské jméno je povinné.")]
    [MaxLength(64, ErrorMessage = "Uživatelské jméno může mít maximálně {0} znaků.")]
    public string Username { get; set; }

    /// <summary>
    /// Heslo
    /// </summary>
    [JsonProperty("password")]
    [Required(ErrorMessage = "Heslo je povinné.")]
    [MaxLength(64, ErrorMessage = "Heslo může mít maximálně {0} znaků.")]
    public string Password { get; set; }
}
