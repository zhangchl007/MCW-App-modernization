namespace CIMobile
{
    public static class ApplicationSettings
    {
        /// <summary>
        /// Enter the root Web API path, once published to Azure.
        /// </summary>
        public static readonly string RootWebApiPath = "";

        /// <summary>
        /// Enter the blob container Url where the policy PDF files are kept. You can find this by navigating to your Storage account
        /// in Azure, clicking on Blobs on the Overview blade, then selecting the container (such as "policies") within the Blob service
        /// blade, and finally clicking Properties, then the copy button next to the URL.
        /// </summary>
        public static readonly string BlobContainerUrl = "";

        /// <summary>
        /// In Azure, select your search service, then the "policies" index, then "Search explorer". Copy the full URL within the
        /// Request URL field. Make sure to include the entire path, even the "&search=*" at the end.
        /// </summary>
        public static readonly string AzureSearchServiceUrl = "";

        /// <summary>
        /// Enter the Azure Search query API key. This can be found by selecting your search service in Azure, then clicking on Keys,
        /// click on Manage query keys, then copy the displayed key (or create one if none exist).
        /// </summary>
        public static readonly string AzureSearchQueryApiKey = "";

        /// <summary>
        /// Enter the api key to call the Azure API Management service.
        /// </summary>
        public static readonly string AzureApiManagementKey = "";
    }
}