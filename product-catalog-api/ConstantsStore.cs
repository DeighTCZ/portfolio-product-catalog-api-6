namespace product_catalog_api;

/// <summary>
/// Konstanty
/// </summary>
public static class ConstantsStore
{
    /// <summary>
    /// Konstanty pro api
    /// </summary>
    internal static class ApiConstants
    {
        internal const int DefaultPage = 1;
        internal const int DefaultItemCount = 10;
    }

    internal static class JwtConstants
    {
        public const string TokenIssuer = "product-catalog-api";

        /// <summary>
        /// Tohle by tady nemělo být. Mělo by to být součástí konfigurace a ne v kódu na gitu.
        /// </summary>
        public const string TokenSecret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==";
    }
}
