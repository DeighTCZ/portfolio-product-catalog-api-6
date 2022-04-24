using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Model.Security;

namespace product_catalog_data_access.Dao.Mock;

/// <summary>
/// Zatím nebudu implementovat
/// </summary>
public class MockUserDao : IUserDao
{
    /// <inheritdoc />
    public Task<IEnumerable<User>> GetAll(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IEnumerable<User>> GetAllPaged(int page, int count, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<User> GetById(long id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<long> Create(User item, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Update(long id, User item, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Delete(long id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<User> GetByLogin(string login, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
