namespace product_catalog_data_model.Exceptions;

/// <summary>
/// Item nebyl naleze vyjímka
/// </summary>
public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() { }

    public ItemNotFoundException(string message) : base(message) { }

    public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

}
