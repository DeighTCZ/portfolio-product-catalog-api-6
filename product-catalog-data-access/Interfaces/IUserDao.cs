using product_catalog_data_model.Model.Security;

namespace product_catalog_data_access.Interfaces;

/// <summary>
/// interface pro dao uživatelů
/// </summary>
public interface IUserDao : IDao<User>
{
    /// <summary>
    /// Vrátí uživatele podle loginu
    /// </summary>
    /// <param name="login"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<User> GetByLogin(string login, CancellationToken ct);
}
