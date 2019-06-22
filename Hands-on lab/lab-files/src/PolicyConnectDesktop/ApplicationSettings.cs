using System.Configuration;

namespace PolicyConnectDesktop
{
    /// <summary>
    /// Global application settings.
    /// </summary>
    public static class ApplicationSettings
    {
        /// <summary>
        /// The root folder of the Pdf files. Could be a network share.
        /// </summary>
        public static readonly string RootPdfPath = ConfigurationManager.AppSettings["PdfRootPath"];

        /// <summary>
        /// If set to true, IServiceCalls references are instantiated as WebApiCalls. Otherwise, WcfCalls.
        /// </summary>
        public static bool UseWebApi
        {
            get
            {
                var value = false;
                bool.TryParse(ConfigurationManager.AppSettings["UseWebApi"], out value);
                return value;
            }
        }

        /// <summary>
        /// Enter the root Web API path, once published to Azure.
        /// </summary>
        public static readonly string RootWebApiPath = ConfigurationManager.AppSettings["RootWebApiPath"];
    }
}
