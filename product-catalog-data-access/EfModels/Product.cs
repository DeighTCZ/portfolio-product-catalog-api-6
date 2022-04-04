namespace product_catalog_data_access.EfModels;

/// <summary>
/// Vygenerovaný objekt z tabulky [dbo].[product]
/// </summary>
public partial class Product
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public string ImageUri { get; set; }
    public decimal Price { get; set; }
}
