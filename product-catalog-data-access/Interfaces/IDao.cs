namespace product_catalog_data_access.Interfaces;

/// <summary>
/// Interface pro základní CRUD operace u dao objektů
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDao<T>
{
    /// <summary>
    /// Vrátí kompletní seznam entit
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<IEnumerable<T>> GetAll(CancellationToken ct);

    /// <summary>
    /// Vrátí kompletní seznam entit
    /// </summary>
    /// <param name="page"></param>
    /// <param name="count"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<IEnumerable<T>> GetAllPaged(int page, int count, CancellationToken ct);

    /// <summary>
    /// Vrátí entitu podle id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<T> GetById(long id, CancellationToken ct);

    /// <summary>
    /// Vytvoří entitu
    /// </summary>
    /// <param name="item"></param>
    /// <param name="ct"></param>
    public Task<long> Create(T item, CancellationToken ct);

    /// <summary>
    /// Upraví entitu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item"></param>
    /// <param name="ct"></param>
    public Task Update(long id, T item, CancellationToken ct);

    /// <summary>
    /// Smaže entitu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    public Task Delete(long id, CancellationToken ct);
}
