namespace product_catalog_data_access;

/// <summary>
/// UtilityClass
/// </summary>
public static class Utility
{
    /// <summary>
    /// Počet prvků které se mají vynechat pro danou stránku
    /// </summary>
    /// <param name="page"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int SkipForPage(int page, int count)
    {
        return (page - 1) * count;
    }
}
