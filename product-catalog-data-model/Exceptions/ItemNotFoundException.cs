namespace product_catalog_data_model.Exceptions;

/// <summary>
/// Item nebyl naleze vyjímka
/// </summary>
public class ItemNotFoundException : Exception
{
    /// <summary>
    /// ctor
    /// </summary>
    public ItemNotFoundException() { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="message"></param>
    public ItemNotFoundException(string message) : base(message) { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
