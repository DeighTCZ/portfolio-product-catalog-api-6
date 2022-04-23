using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace product_catalog_api.Model.Dto;

/// <summary>
/// Model pro stránkování
/// </summary>
public class PaginationDto
{
    /// <summary>
    /// ctor
    /// </summary>
    public PaginationDto()
    {
        Page = 1;
        Count = ConstantsStore.ApiConstants.DefaultItemCount;
    }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="page"></param>
    /// <param name="count"></param>
    public PaginationDto(int page, int count)
    {
        Page = page;
        Count = count;
    }

    /// <summary>
    /// Stránka
    /// </summary>
    [JsonProperty("page")]
    [Range(1, int.MaxValue, ErrorMessage = "Minimální možná stránka je 1.")]
    public int Page { get; set; }

    /// <summary>
    /// Počet prvků na stránku
    /// </summary>
    [JsonProperty("count")]
    [Range(1, int.MaxValue, ErrorMessage = "Minimální počet prvků na stránku je 1.")]
    public int Count { get; set; }
}
