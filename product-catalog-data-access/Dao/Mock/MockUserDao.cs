using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Model.Security;

namespace product_catalog_data_access.Dao.Mock;

/// <summary>
/// Zatím nebudu implementovat
/// </summary>
public class MockUserDao : IUserDao
{
    /// <inheritdoc />
    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IEnumerable<User>> GetAllPaged(int page, int count)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<User> GetById(long id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Create(User item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Update(User item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<User> GetByLogin(string login)
    {
        throw new NotImplementedException();
    }
}
