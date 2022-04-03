namespace product_catalog_data_model.Model.Security;

/// <summary>
/// Model pro uživatele pro potřeby aplikace
/// </summary>
public class User
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// Login uživatele
    /// </summary>
    public string Login { get; init; }

    /// <summary>
    /// Heslo uživatele
    /// </summary>
    public string Password { get; init; }
}
