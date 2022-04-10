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
    /// <returns></returns>
    public Task<IEnumerable<T>> GetAll();

    /// <summary>
    /// Vrátí kompletní seznam entit
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<T>> GetAllPaged(int page, int count);

    /// <summary>
    /// Vrátí entitu podle id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<T> GetById(long id);

    /// <summary>
    /// Vytvoří entitu
    /// </summary>
    /// <param name="item"></param>
    public Task Create(T item);

    /// <summary>
    /// Upraví entitu
    /// </summary>
    /// <param name="item"></param>
    public Task Update(T item);

    /// <summary>
    /// Smaže entitu
    /// </summary>
    /// <param name="id"></param>
    public Task Delete(long id);
}
