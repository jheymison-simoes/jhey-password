using System.Security.Cryptography;

namespace JheyPassword.Business.Helpers;

public class EncryptionHelper
{
    public static (string EncryptedText, string Key, string IV) Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        using (var writer = new StreamWriter(cryptoStream))
        {
            writer.Write(plainText);
        }

        return (Convert.ToBase64String(memoryStream.ToArray()), Convert.ToBase64String(aes.Key), Convert.ToBase64String(aes.IV));
    }
    
    public static string Decrypt(string encryptedText, string key, string iv)
    {
        var cipherBytes = Convert.FromBase64String(encryptedText);
        var keyBytes = Convert.FromBase64String(key);
        var ivBytes = Convert.FromBase64String(iv);

        using var aes = Aes.Create();
        var decryptor = aes.CreateDecryptor(keyBytes, ivBytes);

        using var memoryStream = new MemoryStream(cipherBytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream);
        return reader.ReadToEnd();
    }
}