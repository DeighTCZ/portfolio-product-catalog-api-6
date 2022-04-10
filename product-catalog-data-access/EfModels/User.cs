#pragma warning disable CS1591
namespace product_catalog_data_access.EfModels;

public partial class User
{
    public long Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
