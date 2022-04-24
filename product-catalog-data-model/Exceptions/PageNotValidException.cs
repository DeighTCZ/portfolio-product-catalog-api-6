namespace product_catalog_data_model.Exceptions;

/// <summary>
/// vyjmka pro neplatnou stránku
/// </summary>
public class PageNotValidException : Exception
{
    /// <summary>
    /// ctor
    /// </summary>
    public PageNotValidException() { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="message"></param>
    public PageNotValidException(string message) : base(message) { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public PageNotValidException(string message, Exception innerException) : base(message, innerException) { }
}
