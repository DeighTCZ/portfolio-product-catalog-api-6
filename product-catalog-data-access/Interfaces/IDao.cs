namespace product_catalog_data_access.Interfaces;

public interface IDao<T>
{
    public IEnumerable<T> GetAll();

    public T GetById(long id);

    public void Create(T item);

    public void Update(T item);

    public void Delete(long id);
}
