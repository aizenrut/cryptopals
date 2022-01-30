using System.Security.Cryptography;
using System.Text;

namespace Cryptopals.Set1;

public class AesInEcbMode
{
    private const string KEY = "YELLOW SUBMARINE"; 
    
    public static byte[] Run()
    {
        var base64 = File.ReadAllText("Data/7.txt");
        var bytes = Convert.FromBase64String(base64);
        var keyBytes = Encoding.ASCII.GetBytes(KEY);
        
        using (var aes = Aes.Create())
        {
            aes.Mode = CipherMode.ECB;
            aes.KeySize = 128;
            aes.Key = keyBytes; 
            
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytes, 0 ,bytes.Length);
                }

                return ms.ToArray();
            }
        }
    }
}