using product_catalog_data_model.Model.Security;

namespace product_catalog_api.Model.Security;

/// <summary>
/// Služba pro vytváření tokenů
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Vygeneruje přístupový token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<string> GenerateToken(User user);
}
