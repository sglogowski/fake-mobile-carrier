using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SQLServerAlwaysEncrypted.CEKGenerator
{
    class Program
    {
        // https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/develop-using-always-encrypted-with-net-framework-data-provider?view=sql-server-2017
        static void Main(string[] args)
        {
            byte[] EncryptedColumnEncryptionKey = GetEncryptedColumnEncryptonKey();
            Console.WriteLine("0x" + BitConverter.ToString(EncryptedColumnEncryptionKey).Replace("-", ""));
            Console.ReadKey();
        }

        static byte[] GetEncryptedColumnEncryptonKey()
        {
            int cekLength = 32;
            String certificateStoreLocation = "CurrentUser";
            String certificateThumbprint = "FCA2F7B54CC3A3A80C478A418C600205325C6757";
            // Generate the plaintext column encryption key.
            byte[] columnEncryptionKey = new byte[cekLength];
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(columnEncryptionKey);

            // Encrypt the column encryption key with a certificate.
            string keyPath = String.Format(@"{0}/My/{1}", certificateStoreLocation, certificateThumbprint);
            SqlColumnEncryptionCertificateStoreProvider provider = new SqlColumnEncryptionCertificateStoreProvider();
            return provider.EncryptColumnEncryptionKey(keyPath, @"RSA_OAEP", columnEncryptionKey);
        }
    }
}
