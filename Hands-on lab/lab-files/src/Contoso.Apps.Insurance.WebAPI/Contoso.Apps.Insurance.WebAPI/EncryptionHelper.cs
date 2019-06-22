using System.Threading.Tasks;

namespace Contoso.Apps.Insurance.WebAPI
{
    public class EncryptionHelper
    {
        /// <summary>
        /// The database connection string extracted from a Key Vault secret.
        /// </summary>
        public static string SecretConnectionString { get; private set; }
            
        public static async Task SetConnectionString(string azureKeyVaultConnectionString)
        {
            
        }
    }
}