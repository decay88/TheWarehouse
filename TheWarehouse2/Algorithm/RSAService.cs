using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheWarehouse.Algorithm
{
    class RSAService
    {
        public static RSAService Instance { get; set; } = new RSAService();

        public static void Encrypt(string publicKey, string text, string fileName)
        {
            try
            {
                UnicodeEncoding byteConverter = new UnicodeEncoding();

                byte[] dataToEncrypt = byteConverter.GetBytes(text);
                byte[] encryptedData;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    encryptedData = rsa.Encrypt(dataToEncrypt, false);
                }

                File.WriteAllBytes(fileName, encryptedData);
            } catch(Exception e) { }
        }

        public static string Decrypt(string privateKey, string fileName)
        {
            try
            {
                byte[] dataToDecrypt = File.ReadAllBytes(fileName);
                byte[] decryptedData;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    decryptedData = rsa.Decrypt(dataToDecrypt, false);
                }
                
                UnicodeEncoding byteConverter = new UnicodeEncoding();
                return byteConverter.GetString(decryptedData);
            } catch (Exception e) { }

            return null;
        }
    }
}
