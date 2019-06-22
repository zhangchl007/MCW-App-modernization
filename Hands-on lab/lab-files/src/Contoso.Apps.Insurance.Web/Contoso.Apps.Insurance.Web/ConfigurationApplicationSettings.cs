namespace Contoso.Apps.Insurance.Web
{
    public static class ConfigurationApplicationSettings
    {
        public static string RootWebApiPath { get; private set; }

        public static string Tenant => "";

        public static string WebClientId => "";

        public static string WebApiAppId { get; private set; }

        public static string AzureFunctionsProxyUrl { get; private set; }

        public static void SetConfigSettings(string rootWebApiPath, string webApiAppId, string azureFunctionProxyUrl)
        {
            RootWebApiPath = rootWebApiPath;
            WebApiAppId = webApiAppId;
            AzureFunctionsProxyUrl = azureFunctionProxyUrl;
        }
    }
}