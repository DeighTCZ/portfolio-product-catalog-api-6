namespace product_catalog_data_model.Model;

/// <summary>
/// Model pro produkt pro potřeby aplikace
/// </summary>
public class Product
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// Název produktu
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Popis produktu
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Uri obrázku produktu
    /// </summary>
    public string ImageUri { get; init; }

    /// <summary>
    /// Cena produktu
    /// </summary>
    public decimal Price { get; init; }
}
